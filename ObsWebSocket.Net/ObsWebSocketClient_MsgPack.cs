using System.Buffers;
using System.Net.WebSockets;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Messages;
using ObsWebSocket.Net.Messages.MsgPack;

namespace ObsWebSocket.Net;

public sealed partial class ObsWebSocketClient
{
    private async void Connect_MsgPack(EventSubscriptions eventSubscriptions)
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
            _client.Options.AddSubProtocol("obswebsocket.msgpack");

            await _client.ConnectAsync(_options.Host, default);

            using var owner = MemoryPool<byte>.Shared.Rent();

            while (_client.State == WebSocketState.Open)
            {
                var buffer = owner.Memory;

                var result = await _client.ReceiveAsync(buffer, default);

                if (result.MessageType == WebSocketMessageType.Close) break;

                var message = MessagePackSerializer.Deserialize<Message>(buffer);

                switch (message.OpCode)
                {
                    case OpCode.Hello:
                        OnConnected?.Invoke();

                        var helloMessage = MessagePackSerializer.Deserialize<Message<Hello>>(buffer);
                        var hello = helloMessage.Data;

                        Identify(hello.Authentication, eventSubscriptions);
                        break;
                    case OpCode.Identified:
                        OnIdentified?.Invoke();
                        break;
                    case OpCode.Event:
                        var eventMessage = MessagePackSerializer.Deserialize<Message<Event>>(buffer);
                        HandleEvents(eventMessage.Data);
                        break;
                    case OpCode.RequestResponse:
                        var response = MessagePackSerializer.Deserialize<Message<RequestResponse>>(buffer);
                        var data = DeserializeRequestResponse(response.Data);
                        if (TryRemoveInvocation(response.Data.RequestId, out InvocationRequest irq))
                            DispatchInvocationCompletion(data, irq);

                        break;
                    case OpCode.RequestBatchResponse:
                        var batchResponse = MessagePackSerializer.Deserialize<Message<RequestBatchResponse>>(buffer);
                        var results = batchResponse.Data.Results.Select(re => DeserializeRequestResponse(re)).ToList();
                        if (TryRemoveInvocation(batchResponse.Data.RequestId, out InvocationBatchRequest ibrq))
                            DispatchInvocationCompletion(results, ibrq);

                        break;
                }
            }

            OnClosed?.Invoke();
            if (_options.AutoReconnect) Connect_Json(eventSubscriptions);
        }
        catch (WebSocketException)
        {
            OnClosed?.Invoke();
            if (_options.AutoReconnect) Connect_Json(eventSubscriptions);
        }
    }
}