using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The state of the record output has changed.
/// </summary>
[MessagePackObject]
public class RecordStateChanged
{
    /// <summary>
    ///     Whether the output is active
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }

    /// <summary>
    ///     The specific state of the output
    /// </summary>
    [JsonPropertyName("outputState")]
    [Key("outputState")]
    public string OutputState { get; init; } = null!;

    /// <summary>
    ///     File name for the saved recording, if record stopped. <c>null</c> otherwise
    /// </summary>
    [JsonPropertyName("outputPath")]
    [Key("outputPath")]
    public string? OutputPath { get; init; }
}