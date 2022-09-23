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
        if (_client.State == WebSocketState.Open)
            await _client.CloseAsync(WebSocketCloseStatus.Empty, null, default);

        await _client.ConnectAsync(_address, default);

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
    }

    private static object? DeserializeRequestResponse(in RequestResponse response)
    {
        if (response.ResponseData == null) return null;

        var type = response.RequestType.GetResponseType();

        return type == null
            ? null
            : MessagePackSerializer.Deserialize(type, MessagePackSerializer.Serialize(response.ResponseData));
    }
}