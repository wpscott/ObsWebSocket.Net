using System.Buffers;
using System.Net.WebSockets;
using System.Text.Json;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Messages;
using ObsWebSocket.Net.Messages.Json;

namespace ObsWebSocket.Net;

public sealed partial class ObsWebSocketClient
{
    private async void Connect_Json(EventSubscriptions eventSubscriptions)
    {
        if (_client is { State: WebSocketState.Open or WebSocketState.CloseReceived })
        {
            await _client.CloseAsync(WebSocketCloseStatus.Empty, null, default);
            _client.Abort();

            _client = null;
            GC.Collect();
        }

        try
        {
            _client = new ClientWebSocket();
            _client.Options.AddSubProtocol("obswebsocket.json");

            await _client.ConnectAsync(_options.Host, default);

            using var owner = MemoryPool<byte>.Shared.Rent();

            while (_client.State == WebSocketState.Open)
            {
                var buffer = owner.Memory;

                var result = await _client.ReceiveAsync(buffer, default);

                if (result.MessageType == WebSocketMessageType.Close) break;

                var message = JsonSerializer.Deserialize<Message>(buffer.Span[..result.Count]);

                switch (message?.OpCode)
                {
                    case OpCode.Hello:
                        OnConnected?.Invoke();

                        var hello = message.Data.Deserialize<Hello>();
                        Identify(hello?.Authentication, eventSubscriptions);
                        break;
                    case OpCode.Identified:
                        OnIdentified?.Invoke();
                        break;
                    case OpCode.Event:
                        var evt = message.Data.Deserialize<Event>();
                        HandleEvents(evt);
                        break;
                    case OpCode.RequestResponse:
                        var response = message.Data.Deserialize<RequestResponse>();
                        var data = DeserializeRequestResponse(response);
                        if (TryRemoveInvocation(response?.RequestId, out InvocationRequest? irq))
                            DispatchInvocationCompletion(data, irq);

                        break;
                    case OpCode.RequestBatchResponse:
                        var batchResponse = message.Data.Deserialize<RequestBatchResponse>();
                        var results = new List<object?>();
                        if (batchResponse != null)
                            results = batchResponse.Results.Select(re => DeserializeRequestResponse(re)).ToList();

                        if (TryRemoveInvocation(batchResponse?.RequestId,
                                out InvocationBatchRequest? ibrq))
                            DispatchInvocationCompletion(results, ibrq);
                        break;
                }
            }

            OnClosed?.Invoke();
            if (_options.AutoReconnect)
            {
                await _options.AutoReconnectWait();
                Connect_Json(eventSubscriptions);
            }
        }
        catch (WebSocketException)
        {
            OnClosed?.Invoke();
            if (_options.AutoReconnect)
            {
                await _options.AutoReconnectWait();
                Connect_Json(eventSubscriptions);
            }
        }
    }
}