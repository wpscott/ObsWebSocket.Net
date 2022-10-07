using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the index position of a scene item in a scene.</para>
///     <remarks>
///         <para>An index of 0 is at the bottom of the source list in the UI.</para>
///         Scenes and Groups
///     </remarks>
/// </summary>
[MessagePackObject]
public class GetSceneItemIndex
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
}

/// <summary>
///     Gets the index position of a scene item in a scene.
/// </summary>
[MessagePackObject]
public class GetSceneItemIndexResponse
{
    /// <summary>
    ///     Index position of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemIndex")]
    [Key("sceneItemIndex")]
    public int SceneItemIndex { get; init; }
}