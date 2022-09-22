using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The transform/crop of a scene item has changed.
/// </summary>
[MessagePackObject]
public struct SceneItemTransformChanged
{
    /// <summary>
    ///     Name of the scene the item is in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }

    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    /// <summary>
    ///     New transform/crop info of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemTransform")]
    [Key("sceneItemTransform")]
    public SceneItemTransform SceneItemTransform { get; init; }
}