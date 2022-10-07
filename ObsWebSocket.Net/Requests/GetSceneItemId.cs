using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Searches a scene for a source, and returns its id.
/// </summary>
[MessagePackObject]
public class GetSceneItemId
{
    /// <summary>
    ///     Name of the scene or group to search in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Name of the source to find
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Number of matches to skip during search. &gt;= 0 means first forward. -1 means last (top) item
    /// </summary>
    [JsonPropertyName("searchOffset")]
    [Key("searchOffset")]
    public int? SearchOffset { get; init; }
}

/// <summary>
///     Searches a scene for a source, and returns its id.
/// </summary>
[MessagePackObject]
public class GetSceneItemIdResponse
{
    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}