using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the transform and crop info of a scene item.
/// </summary>
[MessagePackObject]
public struct SetSceneItemTransform
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
    ///     Object containing scene item transform info to update
    /// </summary>
    [JsonPropertyName("sceneItemTransform")]
    [Key("sceneItemTransform")]
    public SceneItemTransform SceneItemTransform { get; init; }
}