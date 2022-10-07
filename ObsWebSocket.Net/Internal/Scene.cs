using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Scene
{
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    [JsonPropertyName("sceneIndex")]
    [Key("sceneIndex")]
    public int SceneIndex { get; init; }
}