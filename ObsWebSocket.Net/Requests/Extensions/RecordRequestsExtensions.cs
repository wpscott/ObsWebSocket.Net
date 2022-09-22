using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class RecordRequestsExtensions
{
    public static Task<GetRecordStatusResponse> GetRecordStatus(this ObsWebSocketClient client)
    {
        return client.Invoke<GetRecordStatusResponse>(RequestType.GetRecordStatus);
    }

    public static void ToggleRecord(this ObsWebSocketClient client)
    {
        client.Send(RequestType.ToggleRecord);
    }

    public static void StartRecord(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StartRecord);
    }

    public static void StopRecord(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StopRecord);
    }

    public static void ToggleRecordPause(this ObsWebSocketClient client)
    {
        client.Send(RequestType.ToggleRecordPause);
    }

    public static void PauseRecord(this ObsWebSocketClient client)
    {
        client.Send(RequestType.PauseRecord);
    }

    public static void ResumeRecord(this ObsWebSocketClient client)
    {
        client.Send(RequestType.ResumeRecord);
    }
}