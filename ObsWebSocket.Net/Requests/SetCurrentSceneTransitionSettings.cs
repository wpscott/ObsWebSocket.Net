using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the settings of the current scene transition.
/// </summary>
[MessagePackObject]
public class SetCurrentSceneTransitionSettings
{
    /// <summary>
    ///     Settings object to apply to the transition. Can be <c>{}</c>
    /// </summary>
    [JsonPropertyName("transitionSettings")]
    [Key("transitionSettings")]
    public IDictionary<string, object> TransitionSettings { get; init; } = null!;

    /// <summary>
    ///     Whether to overlay over the current settings or replace them
    /// </summary>
    [JsonPropertyName("overlay")]
    [Key("overlay")]
    public bool? Overlay { get; init; }
}