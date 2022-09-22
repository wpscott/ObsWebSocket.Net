using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class OutputsRequestsExtensions
{
    public static Task<GetVirtualCamStatusResponse> GetVirtualCamStatus(this ObsWebSocketClient client)
    {
        return client.Invoke<GetVirtualCamStatusResponse>(RequestType.GetVirtualCamStatus);
    }

    public static Task<ToggleVirtualCamResponse> ToggleVirtualCam(this ObsWebSocketClient client)
    {
        return client.Invoke<ToggleVirtualCamResponse>(RequestType.ToggleVirtualCam);
    }

    public static void StartVirtualCam(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StartVirtualCam);
    }

    public static void StopVirtualCam(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StopVirtualCam);
    }

    public static Task<GetReplayBufferStatusResponse> GetReplayBufferStatus(this ObsWebSocketClient client)
    {
        return client.Invoke<GetReplayBufferStatusResponse>(RequestType.GetReplayBufferStatus);
    }

    public static Task<ToggleReplayBufferResponse> ToggleReplayBuffer(this ObsWebSocketClient client)
    {
        return client.Invoke<ToggleReplayBufferResponse>(RequestType.ToggleReplayBuffer);
    }

    public static void StartReplayBuffer(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StartReplayBuffer);
    }

    public static void StopReplayBuffer(this ObsWebSocketClient client)
    {
        client.Send(RequestType.StopReplayBuffer);
    }

    public static void SaveReplayBuffer(this ObsWebSocketClient client)
    {
        client.Send(RequestType.SaveReplayBuffer);
    }

    public static Task<GetLastReplayBufferReplayResponse> GetLastReplayBufferReplay(this ObsWebSocketClient client)
    {
        return client.Invoke<GetLastReplayBufferReplayResponse>(RequestType.GetLastReplayBufferReplay);
    }

    public static Task<GetOutputListResponse> GetOutputList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetOutputListResponse>(RequestType.GetOutputList);
    }

    public static Task<GetOutputStatusResponse> GetOutputStatus(this ObsWebSocketClient client, string outputName)
    {
        return client.Invoke<GetOutputStatusResponse>(RequestType.GetOutputStatus,
            new GetOutputStatus { OutputName = outputName });
    }

    public static Task<ToggleOutputResponse> ToggleOutput(this ObsWebSocketClient client, string outputName)
    {
        return client.Invoke<ToggleOutputResponse>(RequestType.ToggleOutput,
            new ToggleOutput { OutputName = outputName });
    }

    public static void StartOutput(this ObsWebSocketClient client, string outputName)
    {
        client.Send(RequestType.StartOutput, new StartOutput { OutputName = outputName });
    }

    public static void StopOutput(this ObsWebSocketClient client, string outputName)
    {
        client.Send(RequestType.StopOutput, new StopOutput { OutputName = outputName });
    }

    public static Task<GetOutputSettingsResponse> GetOutputSettings(this ObsWebSocketClient client, string outputName)
    {
        return client.Invoke<GetOutputSettingsResponse>(RequestType.GetOutputSettings,
            new GetOutputSettings { OutputName = outputName });
    }

    public static void SetOutputSettings(this ObsWebSocketClient client, string outputName,
        IDictionary<string, object> outputSettings)
    {
        client.Send(RequestType.SetOutputSettings,
            new SetOutputSettings { OutputName = outputName, OutputSettings = outputSettings });
    }
}