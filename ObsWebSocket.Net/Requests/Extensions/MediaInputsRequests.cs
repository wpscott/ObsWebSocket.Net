using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class MediaInputsRequests
{
    public static Task<GetMediaInputStatusResponse> GetMediaInputsStatus(this ObsWebSocketClient client,
        string inputName)
    {
        return client.Invoke<GetMediaInputStatusResponse>(RequestType.GetMediaInputStatus,
            new GetMediaInputStatus { InputName = inputName });
    }

    public static void SetMediaInputCursor(this ObsWebSocketClient client, string inputName, ulong mediaCursor)
    {
        client.Send(RequestType.SetMediaInputCursor,
            new SetMediaInputCursor { InputName = inputName, MediaCursor = mediaCursor });
    }

    public static void OffsetMediaInputCurosr(this ObsWebSocketClient client, string inputName, long mediaCursorOffset)
    {
        client.Send(RequestType.OffsetMediaInputCursor,
            new OffsetMediaInputCursor { InputName = inputName, MediaCursor = mediaCursorOffset });
    }

    public static void TriggerMediaInputAction(this ObsWebSocketClient client, string inputName,
        ObsWebSocketMediaInputAction mediaAction)
    {
        client.Send(RequestType.TriggerMediaInputAction,
            new TriggerMediaInputAction { InputName = inputName, MediaAction = mediaAction });
    }
}