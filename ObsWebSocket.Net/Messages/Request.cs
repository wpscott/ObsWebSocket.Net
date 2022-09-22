using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     <para>Sent from: Identified client</para>
///     <para>Sent to: obs-websocket</para>
///     <para>Description: Client is making a request to obs-websocket. E.g. get current scene, create source.</para>
/// </summary>
[MessagePackObject]
public struct Request<T> where T : struct
{
    [JsonPropertyName("requestType")]
    [Key("requestType")]
    [MessagePackFormatter(typeof(EnumFormatter<RequestType>))]
    public RequestType RequestType { get; init; }

    [JsonPropertyName("requestId")]
    [Key("requestId")]
    public string RequestId { get; init; }

    [JsonPropertyName("requestData")]
    [Key("requestData")]
    public T? RequestData { get; init; }
}

/// <summary>
///     <para>Sent from: Identified client</para>
///     <para>Sent to: obs-websocket</para>
///     <para>Description: Client is making a request to obs-websocket. E.g. get current scene, create source.</para>
/// </summary>
[MessagePackObject]
public struct Request
{
    [JsonPropertyName("requestType")]
    [Key("requestType")]
    [MessagePackFormatter(typeof(EnumFormatter<RequestType>))]
    public RequestType RequestType { get; init; }

    [JsonPropertyName("requestId")]
    [Key("requestId")]
    public string RequestId { get; init; }

    [JsonPropertyName("requestData")]
    [Key("requestData")]
    public object? RequestData { get; init; }
}