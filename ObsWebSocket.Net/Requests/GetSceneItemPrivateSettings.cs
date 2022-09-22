using MessagePack;
using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject()]
public struct GetSceneItemPrivateSettings
{
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }


    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}

[MessagePackObject()]
public struct GetSceneItemPrivateSettingsResponse
{
    [JsonPropertyName("sceneItemSettings")]
    [Key("sceneItemSettings")]
    public IReadOnlyDictionary<string, object> SceneItemSettings { get; init; }
}