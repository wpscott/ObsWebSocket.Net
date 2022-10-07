using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene item has been created.
/// </summary>
[MessagePackObject]
public class SceneItemCreated
{
    /// <summary>
    ///     Name of the scene the item was added to
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Name of the underlying source (input/scene)
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    /// <summary>
    ///     Index position of the item
    /// </summary>
    [JsonPropertyName("sceneItemIndex")]
    [Key("sceneItemIndex")]
    public int SceneItemIndex { get; init; }
}