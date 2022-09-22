using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class UiRequestsExtensions
{
    public static Task<GetStudioModeEnabledResponse> GetStudioModeEnabled(this ObsWebSocketClient client)
    {
        return client.Invoke<GetStudioModeEnabledResponse>(RequestType.GetStudioModeEnabled);
    }

    public static void SetStudioModeEnabled(this ObsWebSocketClient client, bool studioModeEnabled)
    {
        client.Send(RequestType.SetStudioModeEnabled,
            new SetStudioModeEnabled { StudioModeEnabled = studioModeEnabled });
    }

    public static void OpenInputPropertiesDialog(this ObsWebSocketClient client, string inputName)
    {
        client.Send(RequestType.OpenInputPropertiesDialog, new OpenInputPropertiesDialog { InputName = inputName });
    }

    public static void OpenInputFiltersDialog(this ObsWebSocketClient client, string inputName)
    {
        client.Send(RequestType.OpenInputFiltersDialog, new OpenInputFiltersDialog { InputName = inputName });
    }

    public static void OpenInputInteractDialog(this ObsWebSocketClient client, string inputName)
    {
        client.Send(RequestType.OpenInputInteractDialog, new OpenInputInteractDialog { InputName = inputName });
    }

    public static Task<GetMonitorListResponse> GetMonitorList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetMonitorListResponse>(RequestType.GetMonitorList);
    }

    public static void OpenVideoMixProjector(this ObsWebSocketClient client, ObsWebSocketVideoMixType videoMixType,
        int? monitorIndex = null, string? projectorGeometry = null)
    {
        client.Send(RequestType.OpenVideoMixProjector,
            new OpenVideoMixProjector
                { VideoMixType = videoMixType, MonitorIndex = monitorIndex, ProjectorGeometry = projectorGeometry });
    }

    public static void OpenSourceProjector(this ObsWebSocketClient client, string sourceName, int? monitorIndex = null,
        string? projectorGeometry = null)
    {
        client.Send(RequestType.OpenSourceProjector,
            new OpenSourceProjector
                { SourceName = sourceName, MonitorIndex = monitorIndex, ProjectorGeometry = projectorGeometry });
    }
}