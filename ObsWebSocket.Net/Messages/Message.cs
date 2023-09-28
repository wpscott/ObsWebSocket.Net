using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     The following message types are the low-level message types which may be sent to and from obs-websocket.
/// </summary>
[MessagePackObject]
public class Message<T> where T : class
{
    /// <summary>
    ///     <see cref="OpCode" /> is a <see cref="WebSocketOpCode" />.
    /// </summary>
    [JsonPropertyName("op")]
    [Key("op")]
    public WebSocketOpCode OpCode { get; init; }

    /// <summary>
    ///     <see cref="Data" /> is an object of the data fields associated with the operation.
    /// </summary>
    [JsonPropertyName("d")]
    [Key("d")]
    public T Data { get; init; } = null!;
}