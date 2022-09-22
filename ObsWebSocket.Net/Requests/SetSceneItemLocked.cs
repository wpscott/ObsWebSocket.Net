using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the lock state of a scene item.</para>
///     <remarks>Scenes and Groups</remarks>
/// </summary>
[MessagePackObject]
public struct SetSceneItemLocked
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
    ///     New lock state of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemLocked")]
    [Key("sceneItemLocked")]
    public bool SceneItemLocked { get; init; }
}