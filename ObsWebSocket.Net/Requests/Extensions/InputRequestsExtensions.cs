using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class InputRequestsExtensions
{
    public static Task<GetInputListResponse> GetInputList(this ObsWebSocketClient client, string? inputKind = null)
    {
        return client.Invoke<GetInputListResponse>(RequestType.GetInputList,
            new GetInputList { InputKind = inputKind });
    }

    public static Task<GetInputKindListResponse> GetInputKindList(this ObsWebSocketClient client,
        bool? unversioned = null)
    {
        return client.Invoke<GetInputKindListResponse>(RequestType.GetInputKindList,
            new GetInputKindList { Unversioned = unversioned });
    }

    public static Task<GetSpecialInputsResponse> GetSpecialInputs(this ObsWebSocketClient client)
    {
        return client.Invoke<GetSpecialInputsResponse>(RequestType.GetSpecialInputs);
    }

    public static Task<CreateInputResponse> CreateInput(this ObsWebSocketClient client, string sceneName,
        string inputName, string inputKind, IDictionary<string, object>? inputSettings = null,
        bool? sceneItemEnabled = null)
    {
        return client.Invoke<CreateInputResponse>(RequestType.CreateInput, new CreateInput
        {
            SceneName = sceneName,
            InputName = inputName,
            InputKind = inputKind,
            InputSettings = inputSettings,
            SceneItemEnabled = sceneItemEnabled
        });
    }

    public static void RemoveInput(this ObsWebSocketClient client, string inputName)
    {
        client.Send(RequestType.RemoveInput, new RemoveInput { InputName = inputName });
    }

    public static void SetInputName(this ObsWebSocketClient client, string inputName, string newInputName)
    {
        client.Send(RequestType.SetInputName, new SetInputName { InputName = inputName, NewInputName = newInputName });
    }

    public static Task<GetInputDefaultSettingsResponse> GetInputDefaultSettings(this ObsWebSocketClient client,
        string inputKind)
    {
        return client.Invoke<GetInputDefaultSettingsResponse>(RequestType.GetInputDefaultSettings,
            new GetInputDefaultSettings { InputKind = inputKind });
    }

    public static Task<GetInputSettingsResponse> GetInputSettings(this ObsWebSocketClient client, string inputName)
    {
        return client.Invoke<GetInputSettingsResponse>(RequestType.GetInputSettings,
            new GetInputSettings { InputName = inputName });
    }

    public static void SetInputSettings(this ObsWebSocketClient client, string inputName,
        IDictionary<string, object> inputSettings, bool? overlay = null)
    {
        client.Send(RequestType.SetInputSettings,
            new SetInputSettings { InputName = inputName, InputSettings = inputSettings, Overlay = overlay });
    }

    public static Task<GetInputMuteResponse> GetInputMute(this ObsWebSocketClient client, string inputName)
    {
        return client.Invoke<GetInputMuteResponse>(RequestType.GetInputMute,
            new GetInputMute { InputName = inputName });
    }

    public static void SetInputMute(this ObsWebSocketClient client, string inputName, bool inputMuted)
    {
        client.Send(RequestType.SetInputMute, new SetInputMute { InputName = inputName, InputMuted = inputMuted });
    }

    public static void ToggleInputMute(this ObsWebSocketClient client, string inputName)
    {
        client.Send(RequestType.ToggleInputMute, new ToggleInputMute { InputName = inputName });
    }

    public static Task<GetInputVolumeResponse> GetInputVolume(this ObsWebSocketClient client, string inputName)
    {
        return client.Invoke<GetInputVolumeResponse>(RequestType.GetInputVolume,
            new GetInputVolume { InputName = inputName });
    }

    public static void SetInputVolume(this ObsWebSocketClient client, string inputName, float? inputVolumeMul = null,
        float? inputVolumeDb = null)
    {
        if (inputVolumeMul is < 0 or > 20) throw new ArgumentOutOfRangeException(nameof(inputVolumeMul));

        if (inputVolumeDb is < -100 or > 26) throw new ArgumentOutOfRangeException(nameof(inputVolumeDb));

        if (inputVolumeMul == null && inputVolumeDb == null)
            throw new ArgumentNullException("",
                $"One of {nameof(inputVolumeMul)} or {nameof(inputVolumeDb)} should be specified");

        client.Send(RequestType.SetInputVolume, new SetInputVolume
        {
            InputName = inputName
        });
    }

    public static Task<GetInputAudioBalanceResponse> GetInputAudioBalance(this ObsWebSocketClient client,
        string inputName)
    {
        return client.Invoke<GetInputAudioBalanceResponse>(RequestType.GetInputAudioBalance,
            new GetInputAudioBalance { InputName = inputName });
    }

    public static void SetInputAudioBalance(this ObsWebSocketClient client, string inputName, float inputAudioBalance)
    {
        client.Send(RequestType.SetInputAudioBalance,
            new SetInputAudioBalance { InputName = inputName, InputAudioBalance = inputAudioBalance });
    }

    public static Task<GetInputAudioSyncOffsetResponse> GetInputAudioSyncOffset(this ObsWebSocketClient client,
        string inputName)
    {
        return client.Invoke<GetInputAudioSyncOffsetResponse>(RequestType.GetInputAudioSyncOffset,
            new GetInputAudioSyncOffset { InputName = inputName });
    }

    public static void SetInputAudioSyncOffset(this ObsWebSocketClient client, string inputName,
        int inputAudioSyncOffset)
    {
        client.Send(RequestType.SetInputAudioSyncOffset,
            new SetInputAudioSyncOffset { InputName = inputName, InputAudioSyncOffset = inputAudioSyncOffset });
    }

    public static Task<GetInputAudioMonitorTypeResponse> GetInputAudioMonitorType(this ObsWebSocketClient client,
        string inputName)
    {
        return client.Invoke<GetInputAudioMonitorTypeResponse>(RequestType.GetInputAudioMonitorType,
            new GetInputAudioMonitorType { InputName = inputName });
    }

    public static void SetInputAudioMonitorType(this ObsWebSocketClient client, string inputName,
        ObsMonitoringType monitorType)
    {
        client.Send(RequestType.SetInputAudioMonitorType,
            new SetInputAudioMonitorType { InputName = inputName, MonitorType = monitorType });
    }

    public static Task<GetInputAudioTracksResponse> GetInputAudioTracks(this ObsWebSocketClient client,
        string inputName)
    {
        return client.Invoke<GetInputAudioTracksResponse>(RequestType.GetInputAudioTracks,
            new GetInputAudioTracks { InputName = inputName });
    }

    public static void SetInputAudioTracks(this ObsWebSocketClient client, string inputName,
        IDictionary<string, bool> inputAudioTracks)
    {
        client.Send(RequestType.SetInputAudioTracks,
            new SetInputAudioTracks { InputName = inputName, InputAudioTracks = inputAudioTracks });
    }

    public static Task<GetInputPropertiesListPropertyItemsResponse> GetInputPropertiesListPropertyItems(
        this ObsWebSocketClient client, string inputName, string propertyName)
    {
        return client.Invoke<GetInputPropertiesListPropertyItemsResponse>(
            RequestType.GetInputPropertiesListPropertyItems,
            new GetInputPropertiesListPropertyItems { InputName = inputName, PropertyName = propertyName });
    }

    public static void PressInputPropertiesButton(this ObsWebSocketClient client, string inputName, string propertyName)
    {
        client.Send(RequestType.PressInputPropertiesButton,
            new PressInputPropertiesButton { InputName = inputName, PropertyName = propertyName });
    }
}