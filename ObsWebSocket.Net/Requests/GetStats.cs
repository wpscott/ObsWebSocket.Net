using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets statistics about OBS, obs-websocket, and the current session.
/// </summary>
[MessagePackObject]
public struct GetStatsResponse
{
    /// <summary>
    ///     Current CPU usage in percent
    /// </summary>
    [JsonPropertyName("cpuUsage")]
    [Key("cpuUsage")]
    public double CpuUsage { get; init; }

    /// <summary>
    ///     Amount of memory in MB currently being used by OBS
    /// </summary>
    [JsonPropertyName("memoryUsage")]
    [Key("memoryUsage")]
    public double MemoryUsage { get; init; }

    /// <summary>
    ///     Available disk space on the device being used for recording storage
    /// </summary>
    [JsonPropertyName("availableDiskSpace")]
    [Key("availableDiskSpace")]
    public double AvailableDiskSpace { get; init; }

    /// <summary>
    ///     Current FPS being rendered
    /// </summary>
    [JsonPropertyName("activeFps")]
    [Key("activeFps")]
    public double ActiveFps { get; init; }

    /// <summary>
    ///     Average time in milliseconds that OBS is taking to render a frame
    /// </summary>
    [JsonPropertyName("averageFrameRenderTime")]
    [Key("averageFrameRenderTime")]
    public double AverageFrameRenderTime { get; init; }

    /// <summary>
    ///     Number of frames skipped by OBS in the render thread
    /// </summary>
    [JsonPropertyName("renderSkippedFrames")]
    [Key("renderSkippedFrames")]
    public uint RenderSkippedFrames { get; init; }

    /// <summary>
    ///     Total number of frames outputted by the render thread
    /// </summary>
    [JsonPropertyName("renderTotalFrames")]
    [Key("renderTotalFrames")]
    public uint RenderTotalFrames { get; init; }

    /// <summary>
    ///     Number of frames skipped by OBS in the output thread
    /// </summary>
    [JsonPropertyName("outputSkippedFrames")]
    [Key("outputSkippedFrames")]
    public uint OutputSkippedFrames { get; init; }

    /// <summary>
    ///     Total number of frames outputted by the output thread
    /// </summary>
    [JsonPropertyName("outputTotalFrames")]
    [Key("outputTotalFrames")]
    public uint OutputTotalFrames { get; init; }

    /// <summary>
    ///     Total number of messages received by obs-websocket from the client
    /// </summary>
    [JsonPropertyName("webSocketSessionIncomingMessages")]
    [Key("webSocketSessionIncomingMessages")]
    public uint WebSocketSessionIncomingMessages { get; init; }

    /// <summary>
    ///     Total number of messages sent by obs-websocket to the client
    /// </summary>
    [JsonPropertyName("webSocketSessionOutgoingMessages")]
    [Key("webSocketSessionOutgoingMessages")]
    public uint WebSocketSessionOutgoingMessages { get; init; }
}