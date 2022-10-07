using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets information about the current scene transition.
/// </summary>
[MessagePackObject]
public class GetCurrentSceneTransition
{
    /// <summary>
    ///     Name of the transition
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; } = null!;

    /// <summary>
    ///     Kind of the transition
    /// </summary>
    [JsonPropertyName("transitionKind")]
    [Key("transitionKind")]
    public string TransitionKind { get; init; } = null!;

    /// <summary>
    ///     Whether the transition uses a fixed (unconfigurable) duration
    /// </summary>
    [JsonPropertyName("transitionFixed")]
    [Key("transitionFixed")]
    public bool TransitionFixed { get; init; }

    /// <summary>
    ///     Configured transition duration in milliseconds. <see langword="null" /> if transition is fixed
    /// </summary>
    [JsonPropertyName("transitionDuration")]
    [Key("transitionDuration")]
    public uint? TransitionDuration { get; init; }

    /// <summary>
    ///     Whether the transition supports being configured
    /// </summary>
    [JsonPropertyName("transitionConfigurable")]
    [Key("transitionConfigurable")]
    public bool TransitionConfigurable { get; init; }

    /// <summary>
    ///     Object of settings for the transition. <see langword="null" /> if transition is not configurable
    /// </summary>
    [JsonPropertyName("transitionSettings")]
    [Key("transitionSettings")]
    public IReadOnlyDictionary<string, object>? TransitionSettings { get; init; }
}