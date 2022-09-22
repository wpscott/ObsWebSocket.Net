using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current scene transition has changed.
/// </summary>
[MessagePackObject]
public struct CurrentSceneTransitionChanged
{
    /// <summary>
    ///     Name of the new transition
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; }
}