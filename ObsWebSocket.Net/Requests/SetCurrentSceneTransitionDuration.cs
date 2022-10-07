using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the duration of the current scene transition, if it is not fixed.
/// </summary>
[MessagePackObject]
public class SetCurrentSceneTransitionDuration
{
    /// <summary>
    ///     <para>Duration in milliseconds</para>
    ///     <remarks>50 &lt;= value &lt;= 20000</remarks>
    /// </summary>
    [JsonPropertyName("transitionDuration")]
    [Key("transitionDuration")]
    public uint TransitionDuration { get; init; }
}