using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Stops an output.
/// </summary>
[MessagePackObject]
public class StopOutput
{
    /// <summary>
    ///     Output name
    /// </summary>
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; } = null!;
}