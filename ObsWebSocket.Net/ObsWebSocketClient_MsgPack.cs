using System.Net.WebSockets;
using MessagePack;
using ObsWebSocket.Net.Messages;
using ObsWebSocket.Net.Messages.MsgPack;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net;

public sealed partial class ObsWebSocketClient
{
    private void MsgPack_Handler(in ReadOnlyMemory<byte> buffer, in WebSocketReceiveResult _)
    {
        var message = MessagePackSerializer.Deserialize<Message>(buffer);

        switch (message?.OpCode)
        {
            case WebSocketOpCode.Hello:
                OnConnected?.Invoke();

                var helloMessage = MessagePackSerializer.Deserialize<Message<Hello>>(buffer);
                var hello = helloMessage?.Data;

                Identify(hello?.Authentication, _eventSubscriptions);
                break;
            case WebSocketOpCode.Identified:
                OnIdentified?.Invoke();
                break;
            case WebSocketOpCode.Event:
                var eventMessage = MessagePackSerializer.Deserialize<Message<Event>>(buffer);
                HandleEvents(eventMessage?.Data);
                break;
            case WebSocketOpCode.RequestResponse:
                var response = MessagePackSerializer.Deserialize<Message<RequestResponse>>(buffer);
                var data = DeserializeRequestResponse(response?.Data);

                if (TryRemoveInvocation(response?.Data.RequestId, out InvocationRequest? irq))
                    DispatchInvocationCompletion(data, irq);
                break;
            case WebSocketOpCode.RequestBatchResponse:
                var batchResponse = MessagePackSerializer.Deserialize<Message<RequestBatchResponse>>(buffer);
                var results = new List<object?>();

                if (batchResponse != null)
                    results = batchResponse.Data.Results.Select(re => DeserializeRequestResponse(re)).ToList();

                if (TryRemoveInvocation(batchResponse?.Data.RequestId, out InvocationBatchRequest? ibrq))
                    DispatchInvocationCompletion(results, ibrq);
                break;
        }
    }
}