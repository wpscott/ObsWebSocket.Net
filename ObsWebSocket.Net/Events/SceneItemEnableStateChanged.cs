using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene item's enable state has changed.
/// </summary>
[MessagePackObject]
public struct SceneItemEnableStateChanged
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
    ///     Whether the scene item is enabled (visible)
    /// </summary>
    [JsonPropertyName("sceneItemEnabled")]
    [Key("sceneItemEnabled")]
    public bool SceneItemEnabled { get; init; }
}