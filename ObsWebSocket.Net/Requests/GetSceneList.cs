using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all scenes in OBS.
/// </summary>
[MessagePackObject]
public class GetSceneListResponse
{
    /// <summary>
    ///     Current program scene
    /// </summary>
    [JsonPropertyName("currentProgramSceneName")]
    [Key("currentProgramSceneName")]
    public string CurrentProgramSceneName { get; init; } = null!;

    /// <summary>
    ///     Current preview scene. <see langword="null" /> if not in studio mode
    /// </summary>
    [JsonPropertyName("currentPreviewSceneName")]
    [Key("currentPreviewSceneName")]
    public string CurrentPreviewSceneName { get; init; } = null!;

    /// <summary>
    ///     Array of scenes
    /// </summary>
    [JsonPropertyName("scenes")]
    [Key("scenes")]
    public IReadOnlyList<Scene> Scenes { get; init; } = null!;
}