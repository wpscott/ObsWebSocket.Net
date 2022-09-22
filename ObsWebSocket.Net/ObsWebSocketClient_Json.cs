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
        if (_client.State == WebSocketState.Open)
            await _client.CloseAsync(WebSocketCloseStatus.Empty, null, default);

        await _client.ConnectAsync(_address, default);

        using var owner = MemoryPool<byte>.Shared.Rent();

        while (_client.State == WebSocketState.Open)
        {
            var buffer = owner.Memory;

            var result = await _client.ReceiveAsync(buffer, default);

            if (result.MessageType == WebSocketMessageType.Close) break;

            var message = JsonSerializer.Deserialize<Message>(buffer.Span[..result.Count]);

            switch (message.OpCode)
            {
                case OpCode.Hello:
                    OnConnected?.Invoke();

                    var hello = message.Data.Deserialize<Hello>();
                    Identify(hello.Authentication, eventSubscriptions);
                    break;
                case OpCode.Identified:
                    OnIdentified?.Invoke();
                    break;
                case OpCode.Event:
                    var evt = message.Data.Deserialize<Event>();
                    HandleEvent(evt);
                    break;
                case OpCode.RequestResponse:
                    var response = message.Data.Deserialize<RequestResponse>();
                    var data = DeserializeRequestResponse(response);
                    if (TryRemoveInvocation(response.RequestId, out InvocationRequest irq))
                        DispatchInvocationCompletion(data, irq);

                    break;
                case OpCode.RequestBatchResponse:
                    var batchResponse = message.Data.Deserialize<RequestBatchResponse>();
                    var results = batchResponse.Results.Select(re => DeserializeRequestResponse(re)).ToList();
                    if (TryRemoveInvocation(batchResponse.RequestId, out InvocationBatchRequest ibrq))
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

        return type == null ? null : response.ResponseData.Deserialize(type);
    }

    private void HandleEvent(in Event evt)
    {
        var type = evt.EventType.GetEventType();
        if (type == null) return;

        InvokeEventHandler(evt.EventType, evt.EventData.Deserialize(type));
    }
}