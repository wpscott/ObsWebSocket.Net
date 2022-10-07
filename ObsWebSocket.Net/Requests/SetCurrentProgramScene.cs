using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the current program scene.
/// </summary>
[MessagePackObject]
public class SetCurrentProgramScene
{
    /// <summary>
    ///     Scene to set as the current program scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;
}