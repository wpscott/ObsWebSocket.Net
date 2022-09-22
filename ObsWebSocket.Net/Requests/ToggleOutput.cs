using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Toggles the status of an output.
/// </summary>
[MessagePackObject]
public struct ToggleOutput
{
    /// <summary>
    ///     Output name
    /// </summary>
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; }
}

/// <summary>
///     Toggles the status of an output.
/// </summary>
[MessagePackObject]
public struct ToggleOutputResponse
{
    /// <summary>
    ///     Whether the output is active
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }
}