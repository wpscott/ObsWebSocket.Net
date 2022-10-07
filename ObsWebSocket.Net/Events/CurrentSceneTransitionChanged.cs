using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current scene transition has changed.
/// </summary>
[MessagePackObject]
public class CurrentSceneTransitionChanged
{
    /// <summary>
    ///     Name of the new transition
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; } = null!;
}