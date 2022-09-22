using MessagePack;
using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject()]
public struct SetSceneItemPrivateSettings
{
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }


    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    [JsonPropertyName("sceneItemSettings")]
    [Key("sceneItemSettings")]
    public IDictionary<string, object> SceneItemSettings { get; init; }
}