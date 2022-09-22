using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     <para>A scene transition's video has completed fully.</para>
///     <para>
///         Useful for stinger transitions to tell when the video actually ends.
///         <see cref="SceneTransitionEnded" /> only signifies the cut point, not the completion of
///         transition playback.
///     </para>
///     <remarks>Note: Appears to be called by every transition, regardless of relevance.</remarks>
/// </summary>
[MessagePackObject]
public struct SceneTransitionVideoEnded
{
    /// <summary>
    ///     Scene transition name
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; }
}