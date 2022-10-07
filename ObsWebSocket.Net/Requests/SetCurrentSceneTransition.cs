using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the current scene transition.</para>
///     <remarks>
///         Small note: While the namespace of scene transitions is generally unique, that uniqueness is not a
///         guarantee as it is with other resources like inputs.
///     </remarks>
/// </summary>
[MessagePackObject]
public class SetCurrentSceneTransition
{
    /// <summary>
    ///     Name of the transition to make active
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; } = null!;
}