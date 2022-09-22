using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the status of the record output.
/// </summary>
[MessagePackObject]
public struct GetRecordStatusResponse
{
    /// <summary>
    ///     Whether the output is active
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }

    /// <summary>
    ///     Whether the output is paused
    /// </summary>
    [JsonPropertyName("outputPaused")]
    [Key("outputPaused")]
    public bool OutputPaused { get; init; }

    /// <summary>
    ///     Current formatted timecode string for the output
    /// </summary>
    [JsonPropertyName("outputTimecode")]
    [Key("outputTimecode")]
    public string OutputTimecode { get; init; }

    /// <summary>
    ///     Current duration in milliseconds for the output
    /// </summary>
    [JsonPropertyName("outputDuration")]
    [Key("outputDuration")]
    public ulong OutputDuration { get; init; }

    /// <summary>
    ///     Number of bytes sent by the output
    /// </summary>
    [JsonPropertyName("outputBytes")]
    [Key("outputBytes")]
    public ulong OutputBytes { get; init; }
}