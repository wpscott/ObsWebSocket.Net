using System.Net.WebSockets;
using System.Text.Json;
using ObsWebSocket.Net.Messages;
using ObsWebSocket.Net.Messages.Json;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net;

public sealed partial class ObsWebSocketClient
{
    private void Json_Handler(in ReadOnlyMemory<byte> buffer, in WebSocketReceiveResult result)
    {
        var message = JsonSerializer.Deserialize<Message>(buffer.Span[..result.Count]);

        switch (message?.OpCode)
        {
            case WebSocketOpCode.Hello:
                OnConnected?.Invoke();

                var hello = message.Data.Deserialize<Hello>();
                Identify(hello?.Authentication, _eventSubscriptions);
                break;
            case WebSocketOpCode.Identified:
                OnIdentified?.Invoke();
                break;
            case WebSocketOpCode.Event:
                var evt = message.Data.Deserialize<Event>();
                HandleEvents(evt);
                break;
            case WebSocketOpCode.RequestResponse:
                var response = message.Data.Deserialize<RequestResponse>();
                var data = DeserializeRequestResponse(response);

                if (TryRemoveInvocation(response?.RequestId, out InvocationRequest? irq))
                    DispatchInvocationCompletion(data, irq);
                break;
            case WebSocketOpCode.RequestBatchResponse:
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
}