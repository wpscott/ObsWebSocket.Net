using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class SetSceneItemPrivateSettings
{
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;


    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    [JsonPropertyName("sceneItemSettings")]
    [Key("sceneItemSettings")]
    public IDictionary<string, object> SceneItemSettings { get; init; } = null!;
}