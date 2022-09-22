using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Starts an output.
/// </summary>
[MessagePackObject]
public struct StartOutput
{
    /// <summary>
    ///     Output name
    /// </summary>
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; }
}