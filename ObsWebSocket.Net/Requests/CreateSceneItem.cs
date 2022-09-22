using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Creates a new scene item using a source.
/// </summary>
[MessagePackObject]
public struct CreateSceneItem
{
    /// <summary>
    ///     Name of the scene to create the new item in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }

    /// <summary>
    ///     Name of the source to add to the scene
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    /// <summary>
    ///     Enable state to apply to the scene item on creation
    /// </summary>
    [JsonPropertyName("sceneItemEnabled")]
    [Key("sceneItemEnabled")]
    public bool? SceneItemEnabled { get; init; }
}

/// <summary>
///     Creates a new scene item using a source.
/// </summary>
[MessagePackObject]
public struct CreateSceneItemResponse
{
    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}