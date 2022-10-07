using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Messages.Json;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: Identified client which made the request</para>
///     <para>Description: obs-websocket is responding to a request batch coming from the client.</para>
/// </summary>
public class RequestBatchResponse
{
    [JsonPropertyName("requestId")] public string RequestId { get; init; } = null!;

    [JsonPropertyName("results")] public IReadOnlyList<RequestResponse> Results { get; init; } = null!;
}