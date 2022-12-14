using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the status of the stream output.
/// </summary>
[MessagePackObject]
public class GetStreamStatusResponse
{
    /// <summary>
    ///     Whether the output is active
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }

    /// <summary>
    ///     Whether the output is reconnecting
    /// </summary>
    [JsonPropertyName("outputReconnecting")]
    [Key("outputReconnecting")]
    public bool OutputReconnecting { get; init; }

    /// <summary>
    ///     Current formatted timecode string for the output
    /// </summary>
    [JsonPropertyName("outputTimecode")]
    [Key("outputTimecode")]
    public string OutputTimecode { get; init; } = null!;

    /// <summary>
    ///     Current duration in milliseconds for the output
    /// </summary>
    [JsonPropertyName("outputDuration")]
    [Key("outputDuration")]
    public ulong OutputDuration { get; init; }

    /// <summary>
    ///     Congestion of the output
    /// </summary>
    [JsonPropertyName("outputCongestion")]
    [Key("outputCongestion")]
    public float OutputCongestion { get; init; }

    /// <summary>
    ///     Number of bytes sent by the output
    /// </summary>
    [JsonPropertyName("outputBytes")]
    [Key("outputBytes")]
    public ulong OutputBytes { get; init; }

    /// <summary>
    ///     Number of frames skipped by the output's process
    /// </summary>
    [JsonPropertyName("outputSkippedFrames")]
    [Key("outputSkippedFrames")]
    public uint OutputSkippedFrames { get; init; }

    /// <summary>
    ///     Total number of frames delivered by the output's process
    /// </summary>
    [JsonPropertyName("outputTotalFrames")]
    [Key("outputTotalFrames")]
    public uint OutputTotalFrames { get; init; }
}