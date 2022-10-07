using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene transition has completed fully.
/// </summary>
[MessagePackObject]
public class SceneTransitionEnded
{
    /// <summary>
    ///     Scene transition name
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; } = null!;
}