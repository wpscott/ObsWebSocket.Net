using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class ConfigRequestsExtensions
{
    public static Task<GetPersistentDataResponse> GetPersistentData(this ObsWebSocketClient client,
        ObsWebSocketDataRealm realm, string slotName)
    {
        return client.Invoke<GetPersistentDataResponse>(RequestType.GetPersistentData, new GetPersistentData
        {
            Realm = realm,
            SlotName = slotName
        });
    }

    public static void SetPersistentData(this ObsWebSocketClient client, ObsWebSocketDataRealm realm,
        string slotName, IDictionary<string, object> slotValue)
    {
        client.Send(RequestType.SetPersistentData, new SetPersistentData
        {
            Realm = realm,
            SlotName = slotName,
            SlotValue = slotValue
        });
    }

    public static Task<GetSceneCollectionListResponse> GetSceneCollectionList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetSceneCollectionListResponse>(RequestType.GetSceneCollectionList);
    }

    public static void SetCurrentSceneCollection(this ObsWebSocketClient client, string sceneCollectionName)
    {
        client.Send(RequestType.SetCurrentSceneCollection,
            new SetCurrentSceneCollection { SceneCollectionName = sceneCollectionName });
    }

    public static void CreateSceneCollection(this ObsWebSocketClient client, string sceneCollectionName)
    {
        client.Send(RequestType.CreateSceneCollection,
            new CreateSceneCollection { SceneCollectionName = sceneCollectionName });
    }

    public static Task<GetProfileListResponse> GetProfileList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetProfileListResponse>(RequestType.GetProfileList);
    }

    public static void SetCurrentProfile(this ObsWebSocketClient client, string profileName)
    {
        client.Send(RequestType.SetCurrentProfile, new SetCurrentProfile { ProfileName = profileName });
    }

    public static void CreateProfile(this ObsWebSocketClient client, string profileName)
    {
        client.Send(RequestType.CreateProfile, new CreateProfile { ProfileName = profileName });
    }

    public static void RemoveProfile(this ObsWebSocketClient client, string profileName)
    {
        client.Send(RequestType.RemoveProfile, new RemoveProfile { ProfileName = profileName });
    }

    public static Task<GetProfileParameterResponse> GetProfileParameter(this ObsWebSocketClient client,
        string parameterCategory, string parameterName)
    {
        return client.Invoke<GetProfileParameterResponse>(RequestType.GetProfileParameter,
            new GetProfileParameter
            {
                ParameterCategory = parameterCategory,
                ParameterName = parameterName
            });
    }

    public static void SetProfileParameter(this ObsWebSocketClient client, string parameterCategory,
        string parameterName, string? parameterValue)
    {
        client.Send(RequestType.SetProfileParameter, new SetProfileParameter
        {
            ParameterCategory = parameterCategory,
            ParameterName = parameterName,
            ParameterValue = parameterValue
        });
    }

    public static Task<GetVideoSettingsResponse> GetVideoSettings(this ObsWebSocketClient client)
    {
        return client.Invoke<GetVideoSettingsResponse>(RequestType.GetVideoSettings);
    }

    public static void SetVideoSettings(this ObsWebSocketClient client, uint? fpsNumerator = null,
        uint? fpsDenominator = null, uint? baseWidth = null, uint? baseHeight = null, uint? outputWidth = null,
        uint? outputHeight = null)
    {
        if (fpsNumerator == null && fpsDenominator != null) throw new ArgumentNullException(nameof(fpsNumerator));
        if (fpsNumerator != null && fpsDenominator == null) throw new ArgumentNullException(nameof(fpsDenominator));
        if (baseWidth == null && baseHeight != null) throw new ArgumentNullException(nameof(baseWidth));
        if (baseWidth != null && baseHeight == null) throw new ArgumentNullException(nameof(baseHeight));
        if (outputWidth == null && outputHeight != null) throw new ArgumentNullException(nameof(outputWidth));
        if (outputWidth != null && outputHeight == null) throw new ArgumentNullException(nameof(outputHeight));
        if (fpsNumerator < 1) throw new ArgumentOutOfRangeException(nameof(fpsNumerator));
        if (fpsDenominator < 1) throw new ArgumentOutOfRangeException(nameof(fpsDenominator));
        if (baseWidth is < 1 or > 4096) throw new ArgumentOutOfRangeException(nameof(baseWidth));
        if (baseHeight is < 1 or > 4096) throw new ArgumentOutOfRangeException(nameof(baseHeight));
        if (outputWidth is < 1 or > 4096) throw new ArgumentOutOfRangeException(nameof(outputWidth));
        if (outputHeight is < 1 or > 4096) throw new ArgumentOutOfRangeException(nameof(outputHeight));


        client.Send(RequestType.SetVideoSettings, new SetVideoSettings
        {
            FpsNumerator = fpsNumerator,
            FpsDenominator = fpsDenominator,
            BaseWidth = baseWidth,
            BaseHeight = baseHeight,
            OutputWidth = outputWidth,
            OutputHeight = outputHeight
        });
    }

    public static Task<GetStreamServiceSettingsResponse> GetStreamServiceSettings(
        this ObsWebSocketClient client)
    {
        return client.Invoke<GetStreamServiceSettingsResponse>(RequestType.GetStreamServiceSettings);
    }

    public static void SetStreamServiceSettings(this ObsWebSocketClient client, string streamServiceType,
        IDictionary<string, object> streamServiceSettings)
    {
        client.Send(RequestType.SetStreamServiceSettings, new SetStreamServiceSettings
        {
            StreamServiceType = streamServiceType,
            StreamServiceSettings = streamServiceSettings
        });
    }

    public static Task<GetRecordDirectoryResponse> GetREcordDirectory(this ObsWebSocketClient client)
    {
        return client.Invoke<GetRecordDirectoryResponse>(RequestType.GetRecordDirectory);
    }
}