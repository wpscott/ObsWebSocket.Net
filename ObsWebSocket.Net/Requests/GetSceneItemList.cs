using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets a list of all scene items in a scene.
/// </summary>
[MessagePackObject]
public class GetSceneItemList
{
    /// <summary>
    ///     Name of the scene to get the items of
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;
}

/// <summary>
///     Gets a list of all scene items in a scene.
/// </summary>
[MessagePackObject]
public class GetSceneItemListResponse
{
    /// <summary>
    ///     Array of scene items in the scene
    /// </summary>
    [JsonPropertyName("sceneItems")]
    [Key("sceneItems")]
    public IReadOnlyList<SceneItem> SceneItems { get; init; } = null!;
}