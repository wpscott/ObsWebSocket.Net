using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Duplicates a scene item, copying all transform and crop info.
/// </summary>
[MessagePackObject]
public class DuplicateSceneItem
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
    ///     <para>Name of the scene to create the duplicated item in</para>
    ///     <remarks>if <see langword="null" />, <see cref="SceneName" /> is assumed</remarks>
    /// </summary>
    [JsonPropertyName("destinationSceneName")]
    [Key("destinationSceneName")]
    public string? DestinationSceneName { get; init; }
}

/// <summary>
/// </summary>
[MessagePackObject]
public class DuplicateSceneItemResponse
{
    /// <summary>
    ///     Numeric ID of the duplicated scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}