using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the lock state of a scene item.</para>
///     <remarks>Scenes and Groups</remarks>
/// </summary>
[MessagePackObject]
public struct GetSceneItemLocked
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
}

/// <summary>
///     Gets the enable state of a scene item.
/// </summary>
[MessagePackObject]
public struct GetSceneItemLockedResponse
{
    /// <summary>
    ///     Whether the scene item is locked. <see langword="true" /> for locked, <see langword="false" /> for unlocked
    /// </summary>
    [JsonPropertyName("sceneItemLocked")]
    [Key("sceneItemLocked")]
    public bool SceneItemLocked { get; init; }
}