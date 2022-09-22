using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all scene transitions in OBS.
/// </summary>
[MessagePackObject]
public struct GetSceneTransitionListResponse
{
    /// <summary>
    ///     Name of the current scene transition. Can be <see langword="null" />
    /// </summary>
    [JsonPropertyName("currentSceneTransitionName")]
    [Key("currentSceneTransitionName")]
    public string CurrentSceneTransitionName { get; init; }

    /// <summary>
    ///     Kind of the current scene transition. Can be <see langword="null" />
    /// </summary>
    [JsonPropertyName("currentSceneTransitionKind")]
    [Key("currentSceneTransitionKind")]
    public string CurrentSceneTransitionKind { get; init; }

    /// <summary>
    ///     Array of transitions
    /// </summary>
    [JsonPropertyName("transitions")]
    [Key("transitions")]
    public IReadOnlyList<Transition> Transitions { get; init; }
}