using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Messages.Json;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     <para>Sent from: Identified client</para>
///     <para>Sent to: obs-websocket</para>
///     <para>
///         Description: Client is making a batch of requests for obs-websocket. Requests are processed serially (in
///         order) by the server.
///     </para>
/// </summary>
[MessagePackObject]
public class RequestBatch
{
    [JsonPropertyName("requestId")]
    [Key("requestId")]
    public string RequestId { get; init; } = null!;

    /// <summary>
    ///     When <see cref="HaltOnFailure" /> is <c>true</c>, the processing of requests will be halted on
    ///     first failure. Returns only the processed requests in
    ///     <see cref="RequestBatchResponse" />.
    /// </summary>
    [JsonPropertyName("haltOnFailure")]
    [Key("haltOnFailure")]
    public bool HaltOnFailure { get; init; }

    [JsonPropertyName("executionType")]
    [Key("executionType")]
    public RequestBatchExecutionType ExecutionType { get; init; }

    /// <summary>
    ///     Requests in the <see cref="Requests" /> array follow the same structure as the
    ///     <see cref="Request" /> payload data format, however requestId is an optional field.
    /// </summary>
    [JsonPropertyName("requests")]
    [Key("requests")]
    public ICollection<Request> Requests { get; init; } = null!;
}