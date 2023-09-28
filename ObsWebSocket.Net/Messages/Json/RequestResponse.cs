using System.Text.Json;
using System.Text.Json.Serialization;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages.Json;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: Identified client which made the request</para>
///     <para>Description: obs-websocket is responding to a request coming from a client.</para>
/// </summary>
public class RequestResponse
{
    [JsonPropertyName("requestType")] public RequestType RequestType { get; init; }

    [JsonPropertyName("requestId")] public string RequestId { get; init; } = null!;

    [JsonPropertyName("requestStatus")]
    public RequestResponseStatus RequestRequestResponseStatus { get; init; } = null!;

    [JsonPropertyName("responseData")] public JsonDocument? ResponseData { get; init; }
}