using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current scene transition duration has changed.
/// </summary>
[MessagePackObject]
public struct CurrentSceneTransitionDurationChanged
{
    /// <summary>
    ///     Transition duration in milliseconds
    /// </summary>
    [JsonPropertyName("transitionDuration")]
    [Key("transitionDuration")]
    public ulong TransitionDuration { get; init; }
}