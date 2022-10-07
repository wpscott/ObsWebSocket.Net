using MessagePack;

namespace ObsWebSocket.Net.Messages.MsgPack;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: Identified client which made the request</para>
///     <para>Description: obs-websocket is responding to a request batch coming from the client.</para>
/// </summary>
[MessagePackObject]
public class RequestBatchResponse
{
    [Key("requestId")] public string RequestId { get; init; } = null!;

    [Key("results")] public IReadOnlyList<RequestResponse> Results { get; init; } = null!;
}