using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all inputs in OBS.
/// </summary>
[MessagePackObject]
public struct GetInputList
{
    /// <summary>
    ///     Restrict the array to only inputs of the specified kind
    /// </summary>
    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string? InputKind { get; init; }
}

/// <summary>
///     Gets an array of all inputs in OBS.
/// </summary>
[MessagePackObject]
public struct GetInputListResponse
{
    /// <summary>
    ///     Array of inputs
    /// </summary>
    [JsonPropertyName("inputs")]
    [Key("inputs")]
    public IReadOnlyList<Input> Inputs { get; init; }
}