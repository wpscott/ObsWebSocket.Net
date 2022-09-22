using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sleeps for a time duration or number of frames. Only available in request batches with types
///     <see cref="RequestBatchExecutionType.SerialRealtime" /> or
///     <see cref="RequestBatchExecutionType.SerialFrame" />.
/// </summary>
[MessagePackObject]
public struct Sleep
{
    /// <summary>
    ///     <para>
    ///         Number of milliseconds to sleep for (if
    ///         <see cref="RequestBatchExecutionType.SerialRealtime" /> mode)
    ///     </para>
    ///     <remarks>0 &lt;= value &lt;= 50000</remarks>
    /// </summary>
    [JsonPropertyName("sleepMillis")]
    [Key("sleepMillis")]
    public uint SleepMillis { get; init; }

    /// <summary>
    ///     <para>
    ///         Number of frames to sleep for (if <see cref="RequestBatchExecutionType.SerialFrame" />
    ///         mode)
    ///     </para>
    ///     <remarks>0 &lt;= value &lt;= 10000</remarks>
    /// </summary>
    [JsonPropertyName("sleepFrames")]
    [Key("sleepFrames")]
    public uint SleepFrames { get; init; }
}