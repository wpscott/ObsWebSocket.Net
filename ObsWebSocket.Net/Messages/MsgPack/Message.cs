using MessagePack;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages.MsgPack;

/// <summary>
///     The following message types are the low-level message types which may be sent to and from obs-websocket.
/// </summary>
[MessagePackObject]
public class Message
{
    /// <summary>
    ///     <see cref="OpCode" /> is a <see cref="WebSocketOpCode" />.
    /// </summary>
    [Key("op")]
    public WebSocketOpCode OpCode { get; init; }
}