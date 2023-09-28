using MessagePack;
using ObsWebSocket.Net.Messages;
using ObsWebSocket.Net.Protocol.Enums;
using System.Buffers;
using System.Net.WebSockets;
using System.Text.Json;
using JsonEvent = ObsWebSocket.Net.Messages.Json.Event;
using JsonRequestResponse = ObsWebSocket.Net.Messages.Json.RequestResponse;
using MsgPackEvent = ObsWebSocket.Net.Messages.MsgPack.Event;
using MsgPackRequestResponse = ObsWebSocket.Net.Messages.MsgPack.RequestResponse;

namespace ObsWebSocket.Net;

public delegate void ObsWebSocketConnectedHandler();

public delegate void ObsWebSocketReconnectingHandler();

public delegate void ObsWebSocketConnectionFailedHandler(Exception exception);

public delegate void ObsWebSocketIdentifiedHandler();

public delegate void ObsWebSocketClosedHandler();

public sealed partial class ObsWebSocketClient
{
    private const int RpcVersion = 1;

    private readonly object _lock = new();
    private readonly Dictionary<string, InvocationBatchRequest> _pendingBatchCalls = new(StringComparer.Ordinal);
    private readonly Dictionary<string, InvocationRequest> _pendingCalls = new(StringComparer.Ordinal);

    private ClientWebSocket? _client;

    private EventSubscription _eventSubscriptions = EventSubscription.All;

    private ObsWebSocketClientOptions _options;

    private ulong _requestId = 1;

    public ObsWebSocketClient() : this(new ObsWebSocketClientOptions())
    {
    }

    public ObsWebSocketClient(in string address, in int port, in string? password = null, in bool useMsgPack = false,
        in bool autoReconnect = false,
        in int autoReconnectWaitSeconds = ObsWebSocketClientOptions.DefaultAutoReconnectWaitSeconds) : this(
        new ObsWebSocketClientOptions
        {
            Address = address,
            Port = port,
            Password = password,
            UseMsgPack = useMsgPack,
            AutoReconnect = autoReconnect,
            AutoReconnectWaitSeconds = autoReconnectWaitSeconds
        })
    {
    }

    public ObsWebSocketClient(in ObsWebSocketClientOptions options)
    {
        _options = options;
    }

    private string RequestId => _requestId++.ToString();

    public void Initialize(in ObsWebSocketClientOptions options)
    {
        _options = options;
    }

    public event ObsWebSocketConnectedHandler? OnConnected;
    public event ObsWebSocketReconnectingHandler? OnReconnecting;
    public event ObsWebSocketConnectionFailedHandler? OnConnectionFailed;
    public event ObsWebSocketIdentifiedHandler? OnIdentified;
    public event ObsWebSocketClosedHandler? OnClosed;

    public async void Connect(EventSubscription eventSubscriptions = EventSubscription.All)
    {
        _eventSubscriptions = eventSubscriptions;

        if (_client is { State: WebSocketState.Open or WebSocketState.CloseReceived }) Close();

        try
        {
            _client = new ClientWebSocket();
            _client.Options.AddSubProtocol(_options.UseMsgPack ? "obswebsocket.msgpack" : "obswebsocket.json");

            await _client.ConnectAsync(_options.Host, default);

            using var owner = MemoryPool<byte>.Shared.Rent();

            while (_client.State == WebSocketState.Open)
            {
                var buffer = owner.Memory;

                var result = await _client.ReceiveAsync(buffer, default);

                if (result.MessageType == WebSocketMessageType.Close) break;

                if (_options.UseMsgPack) MsgPack_Handler(buffer, result);
                else Json_Handler(buffer, result);
            }

            OnClosed?.Invoke();
            if (!_options.AutoReconnect) return;
            OnReconnecting?.Invoke();
            await _options.AutoReconnectWait();
            Connect(eventSubscriptions);
        }
        catch (WebSocketException ex)
        {
            OnConnectionFailed?.Invoke(ex);
            if (_options.AutoReconnect)
            {
                OnReconnecting?.Invoke();
                await _options.AutoReconnectWait();
                Connect(eventSubscriptions);
            }
        }
    }

    public void Close()
    {
        if (_client == null) return;
        _client.Abort();
        _client.Dispose();
        _client = null;

        GC.Collect();
    }

    public void Reidentify(in EventSubscription eventSubscriptions = EventSubscription.All)
    {
        var message = new Message<Reidentify>
        {
            OpCode = WebSocketOpCode.Reidentify,
            Data = new Reidentify
            {
                EventSubscriptions = eventSubscriptions
            }
        };

        Send(message);
    }

    public async Task<T?> Invoke<T>(RequestType requestType, object? requestData = null,
        CancellationToken cancellationToken = default) where T : class
    {
        var irq = InvocationRequest.Invoke(RequestId, out var invocationTask, cancellationToken);

        lock (_lock)
        {
            if (_pendingCalls.ContainsKey(irq.RequestId))
                throw new InvalidOperationException($"Request Id '{irq.RequestId}' is already in use.");
            _pendingCalls.Add(irq.RequestId, irq);
        }

        var message = new Message<Request>
        {
            OpCode = WebSocketOpCode.Request,
            Data = new Request
            {
                RequestId = irq.RequestId,
                RequestType = requestType,
                RequestData = requestData
            }
        };
        Send(message);

        return (T?)await invocationTask;
    }

    public async Task<IReadOnlyList<object?>> Invoke(
        RequestBatchExecutionType executionType = RequestBatchExecutionType.SerialRealtime, bool haltOnFailure = false,
        CancellationToken cancellationToken = default, params Request[] requests)
    {
        var irq = InvocationBatchRequest.Invoke(RequestId, out var invocationTask, cancellationToken);
        lock (_lock)
        {
            if (_pendingBatchCalls.ContainsKey(irq.RequestId))
                throw new InvalidOperationException($"Request Id '{irq.RequestId}' is already in use.");
            _pendingBatchCalls.Add(irq.RequestId, irq);
        }

        var message = new Message<RequestBatch>
        {
            OpCode = WebSocketOpCode.RequestBatch,
            Data = new RequestBatch
            {
                ExecutionType = executionType,
                HaltOnFailure = haltOnFailure,
                RequestId = irq.RequestId,
                Requests = requests
            }
        };
        Send(message);

        return await invocationTask;
    }

    private bool TryRemoveInvocation(in string? requestId, out InvocationRequest? irq)
    {
        if (string.IsNullOrEmpty(requestId))
        {
            irq = null;
            return false;
        }

        lock (_lock)
        {
            if (!_pendingCalls.TryGetValue(requestId, out irq!)) return false;
            _pendingCalls.Remove(requestId);
            return true;
        }
    }

    private bool TryRemoveInvocation(in string? requestId, out InvocationBatchRequest? irq)
    {
        if (string.IsNullOrEmpty(requestId))
        {
            irq = null;
            return false;
        }

        lock (_lock)
        {
            if (!_pendingBatchCalls.TryGetValue(requestId, out irq!)) return false;
            _pendingBatchCalls.Remove(requestId);
            return true;
        }
    }

    private static void DispatchInvocationCompletion(in object? data, in InvocationRequest? irq)
    {
        if (irq == null) return;
        if (irq.CancellationToken.IsCancellationRequested)
        {
        }
        else
        {
            irq.Complete(data);
        }
    }

    private static void DispatchInvocationCompletion(in IReadOnlyList<object?> data, in InvocationBatchRequest? irq)
    {
        if (irq == null) return;
        if (irq.CancellationToken.IsCancellationRequested)
        {
        }
        else
        {
            irq.Complete(data);
        }
    }

    public void Send(RequestType requestType, object? requestData = null)
    {
        var message = new Message<Request>
        {
            OpCode = WebSocketOpCode.Request,
            Data = new Request
            {
                RequestId = RequestId,
                RequestType = requestType,
                RequestData = requestData
            }
        };
        Send(message);
    }

    private async void Send(object message)
    {
        if (_client?.State != WebSocketState.Open) return;

        if (_options.UseMsgPack)
            await _client.SendAsync(new ArraySegment<byte>(MessagePackSerializer.Serialize(message)),
                WebSocketMessageType.Binary, WebSocketMessageFlags.EndOfMessage, default);
        else
            await _client.SendAsync(new ArraySegment<byte>(JsonSerializer.SerializeToUtf8Bytes(message)),
                WebSocketMessageType.Text, WebSocketMessageFlags.EndOfMessage, default);
    }

    private void Identify(HelloAuthentication? authentication, EventSubscription eventSubscriptions)
    {
        var response = new Message<Identify>
        {
            OpCode = WebSocketOpCode.Identify,
            Data = new Identify
            {
                RpcVersion = RpcVersion,
                Authentication = authentication?.Authenticate(_options.Password),
                EventSubscriptions = eventSubscriptions
            }
        };

        Send(response);
    }

    private partial void HandleEvents(in JsonEvent? evt);
    private partial void HandleEvents(in MsgPackEvent? evt);

    private static partial object? DeserializeRequestResponse(in JsonRequestResponse? response);
    private static partial object? DeserializeRequestResponse(in MsgPackRequestResponse? response);
}