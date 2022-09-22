using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class StreamRequestsExtensions
{
    public static Task<GetStreamStatusResponse> GetStreamStatus(this ObsWebSocketClient client)
    {
        return client.Invoke<GetStreamStatusResponse>(RequestType.GetStreamStatus);
    }

    public static Task<ToggleStreamResponse> ToggleStream(this ObsWebSocketClient client)
    {
        return client.Invoke<ToggleStreamResponse>(RequestType.ToggleStream);
    }

    public static void StartStream(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StartStream);
    }

    public static void StopStream(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StopStream);
    }

    public static void SendStreamCaption(this ObsWebSocketClient client, string captionText)
    {
        client.Send(RequestType.SendStreamCaption, new SendStreamCaption { CaptionText = captionText });
    }
}