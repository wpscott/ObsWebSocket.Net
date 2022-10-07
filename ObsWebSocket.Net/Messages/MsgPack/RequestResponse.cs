using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Messages.MsgPack;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: Identified client which made the request</para>
///     <para>Description: obs-websocket is responding to a request coming from a client.</para>
/// </summary>
[MessagePackObject]
public class RequestResponse
{
    [Key("requestType")]
    [MessagePackFormatter(typeof(EnumFormatter<RequestType>))]
    public RequestType RequestType { get; init; }

    [Key("requestId")] public string RequestId { get; init; } = null!;

    [Key("requestStatus")] public RequestResponseStatus RequestStatus { get; init; } = null!;

    [Key("responseData")] public object? ResponseData { get; init; }
}