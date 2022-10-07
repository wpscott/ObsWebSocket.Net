using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the current program scene.
/// </summary>
[MessagePackObject]
public class GetCurrentProgramSceneResponse
{
    /// <summary>
    ///     Current program scene
    /// </summary>
    [JsonPropertyName("currentProgramSceneName")]
    [Key("currentProgramSceneName")]
    public string CurrentProgramSceneName { get; init; } = null!;
}