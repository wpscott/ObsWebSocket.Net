using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the enable state of a scene item.</para>
///     <remarks>Scenes and Groups</remarks>
/// </summary>
[MessagePackObject]
public struct GetSceneItemEnabled
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
public struct GetSceneItemEnabledResponse
{
    /// <summary>
    ///     Whether the scene item is enabled. <see langword="true" /> for enabled, <see langword="false" /> for disabled
    /// </summary>
    [JsonPropertyName("sceneItemEnabled")]
    [Key("sceneItemEnabled")]
    public bool SceneItemEnabled { get; init; }
}