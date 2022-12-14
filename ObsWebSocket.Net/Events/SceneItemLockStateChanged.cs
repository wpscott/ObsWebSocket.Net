using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene item's lock state has changed.
/// </summary>
[MessagePackObject]
public class SceneItemLockStateChanged
{
    /// <summary>
    ///     Name of the scene the item is in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    /// <summary>
    ///     Whether the scene item is locked
    /// </summary>
    [JsonPropertyName("sceneItemLocked")]
    [Key("sceneItemLocked")]
    public bool SceneItemLocked { get; init; }
}