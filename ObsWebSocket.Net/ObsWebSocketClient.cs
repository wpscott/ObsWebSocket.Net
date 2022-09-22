using System.Net.WebSockets;
using System.Reflection;
using System.Text.Json;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Messages;

namespace ObsWebSocket.Net;

public delegate void ObsWebSocketConnectedHandler();

public delegate void ObsWebSocketIdentifiedHandler();

public delegate void ObsWebSocketClosedHandler();

public sealed partial class ObsWebSocketClient
{
    private const int RpcVersion = 1;

    private readonly Uri _address;

    private readonly ClientWebSocket _client;

    private readonly object _lock = new();
    private readonly string? _password;
    private readonly Dictionary<string, InvocationBatchRequest> _pendingBatchCalls = new(StringComparer.Ordinal);
    private readonly Dictionary<string, InvocationRequest> _pendingCalls = new(StringComparer.Ordinal);
    private readonly bool _useMsgPack;

    private ulong _requestId = 1;

    public ObsWebSocketClient(in string address, in int port, in string? password = null, in bool useMsgPack = false)
    {
        _address = new Uri($"ws://{address}:{port}");
        _password = password;

        _useMsgPack = useMsgPack;

        _client = new ClientWebSocket();
        _client.Options.AddSubProtocol(useMsgPack ? "obswebsocket.msgpack" : "obswebsocket.json");
    }

    private string RequestId => _requestId++.ToString();


    public event ObsWebSocketConnectedHandler? OnConnected;
    public event ObsWebSocketIdentifiedHandler? OnIdentified;
    public event ObsWebSocketClosedHandler? OnClosed;

    public void Connect(in EventSubscriptions eventSubscriptions = EventSubscriptions.All)
    {
        if (_useMsgPack)
            Connect_MsgPack(eventSubscriptions);
        else
            Connect_Json(eventSubscriptions);
    }

    public async void Close()
    {
        await _client.CloseAsync(WebSocketCloseStatus.Empty, null, default);
    }

    public void Reidentify(in EventSubscriptions eventSubscriptions = EventSubscriptions.All)
    {
        var message = new Message<Reidentify>
        {
            OpCode = OpCode.Reidentify,
            Data = new Reidentify
            {
                EventSubscriptions = eventSubscriptions
            }
        };

        Send(message);
    }

    public async Task<T> Invoke<T>(RequestType requestType, object? requestData = null,
        CancellationToken cancellationToken = default)
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
            OpCode = OpCode.Request,
            Data = new Request
            {
                RequestId = irq.RequestId,
                RequestType = requestType,
                RequestData = requestData
            }
        };
        Send(message);

        return (T)(await invocationTask)!;
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
            OpCode = OpCode.RequestBatch,
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

    private bool TryRemoveInvocation(in string requestId, out InvocationRequest irq)
    {
        lock (_lock)
        {
            if (!_pendingCalls.TryGetValue(requestId, out irq!)) return false;
            _pendingCalls.Remove(requestId);
            return true;
        }
    }

    private bool TryRemoveInvocation(in string requestId, out InvocationBatchRequest irq)
    {
        lock (_lock)
        {
            if (!_pendingBatchCalls.TryGetValue(requestId, out irq!)) return false;
            _pendingBatchCalls.Remove(requestId);
            return true;
        }
    }

    private static void DispatchInvocationCompletion(object? data, InvocationRequest irq)
    {
        if (irq.CancellationToken.IsCancellationRequested)
        {
        }
        else
        {
            irq.Complete(data);
        }
    }

    private static void DispatchInvocationCompletion(IReadOnlyList<object?> data, InvocationBatchRequest irq)
    {
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
            OpCode = OpCode.Request,
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
        if (_client.State != WebSocketState.Open) return;

        if (_useMsgPack)
            await _client.SendAsync(new ArraySegment<byte>(MessagePackSerializer.Serialize(message)),
                WebSocketMessageType.Binary, WebSocketMessageFlags.EndOfMessage, default);
        else
            await _client.SendAsync(new ArraySegment<byte>(JsonSerializer.SerializeToUtf8Bytes(message)),
                WebSocketMessageType.Text, WebSocketMessageFlags.EndOfMessage, default);
    }

    private void Identify(HelloAuthentication? authentication, EventSubscriptions eventSubscriptions)
    {
        var response = new Message<Identify>
        {
            OpCode = OpCode.Identify,
            Data = new Identify
            {
                RpcVersion = RpcVersion,
                Authentication = authentication?.Authenticate(_password),
                EventSubscriptions = eventSubscriptions
            }
        };

        Send(response);
    }

    private void InvokeEventHandler(in EventType eventType, params object?[]? args)
    {
        if (args == null) return;

        if (GetType()?.GetField($"On{eventType}", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(this) is not MulticastDelegate handler) return;
        handler.DynamicInvoke(args);
    }
}