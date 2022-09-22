using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene transition has started.
/// </summary>
[MessagePackObject]
public struct SceneTransitionStarted
{
    /// <summary>
    ///     Scene transition name
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; }
}