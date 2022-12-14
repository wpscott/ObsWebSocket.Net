using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the name of a scene (rename).
/// </summary>
[MessagePackObject]
public class SetSceneName
{
    /// <summary>
    ///     Name of the scene to be renamed
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     New name for the scene
    /// </summary>
    [JsonPropertyName("newSceneName")]
    [Key("newSceneName")]
    public string NewSceneName { get; init; } = null!;
}