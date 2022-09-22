using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the settings of an output.
/// </summary>
[MessagePackObject]
public struct SetOutputSettings
{
    /// <summary>
    ///     Output name
    /// </summary>
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; }

    /// <summary>
    ///     Output settings
    /// </summary>
    [JsonPropertyName("outputSettings")]
    [Key("outputSettings")]
    public IDictionary<string, object> OutputSettings { get; init; }
}