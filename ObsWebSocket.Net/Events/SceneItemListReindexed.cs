using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene's item list has been reindexed.
/// </summary>
[MessagePackObject]
public class SceneItemListReindexed
{
    /// <summary>
    ///     Name of the scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Array of scene item objects
    /// </summary>
    [JsonPropertyName("sceneItems")]
    [Key("sceneItems")]
    public IReadOnlyList<SceneItem> SceneItems { get; init; } = null!;
}