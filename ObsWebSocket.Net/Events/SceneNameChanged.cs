using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The name of a scene has changed.
/// </summary>
[MessagePackObject]
public struct SceneNameChanged
{
    /// <summary>
    ///     Old name of the scene
    /// </summary>
    [JsonPropertyName("oldSceneName")]
    [Key("oldSceneName")]
    public string OldSceneName { get; init; }

    /// <summary>
    ///     New name of the scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }
}