using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current program scene has changed.
/// </summary>
[MessagePackObject]
public class CurrentProgramSceneChanged
{
    /// <summary>
    ///     Name of the scene that was switched to
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;
}