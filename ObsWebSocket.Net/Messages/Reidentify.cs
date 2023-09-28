using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     <para>Sent from: Identified client</para>
///     <para>Sent to: obs-websocket</para>
///     <para>Description: Sent at any time after initial identification to update the provided session parameters.</para>
///     <remarks>
///         Only the listed parameters may be changed after initial identification. To change a parameter not listed,
///         you must reconnect to the obs-websocket server.
///     </remarks>
/// </summary>
[MessagePackObject]
public class Reidentify
{
    [JsonPropertyName("eventSubscriptions")]
    [Key("eventSubscriptions")]
    public EventSubscription EventSubscriptions { get; init; }
}