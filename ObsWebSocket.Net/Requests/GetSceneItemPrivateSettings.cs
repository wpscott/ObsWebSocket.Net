using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class GetSceneItemPrivateSettings
{
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;


    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}

[MessagePackObject]
public class GetSceneItemPrivateSettingsResponse
{
    [JsonPropertyName("sceneItemSettings")]
    [Key("sceneItemSettings")]
    public IReadOnlyDictionary<string, object> SceneItemSettings { get; init; } = null!;
}