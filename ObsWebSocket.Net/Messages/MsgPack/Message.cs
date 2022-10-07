using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Messages.MsgPack;

/// <summary>
///     The following message types are the low-level message types which may be sent to and from obs-websocket.
/// </summary>
[MessagePackObject]
public class Message
{
    /// <summary>
    ///     <see cref="OpCode" /> is a <see cref="Enums.OpCode" />.
    /// </summary>
    [Key("op")]
    public OpCode OpCode { get; init; }
}