using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets an array of all available transition kinds.</para>
///     <para>Similar to <see cref="GetInputKindList" /></para>
/// </summary>
[MessagePackObject]
public struct GetTransitionKindListResponse
{
    /// <summary>
    ///     Array of transition kinds
    /// </summary>
    [JsonPropertyName("transitionKinds")]
    [Key("transitionKinds")]
    public IReadOnlyList<string> TransitionKinds { get; init; }
}