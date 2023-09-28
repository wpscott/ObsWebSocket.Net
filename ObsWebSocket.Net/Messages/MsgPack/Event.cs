using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages.MsgPack;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: All subscribed and identified clients</para>
///     <para>Description: An event coming from OBS has occured. Eg scene switched, source muted.</para>
/// </summary>
[MessagePackObject]
public class Event
{
    [Key("eventType")]
    [MessagePackFormatter(typeof(EnumFormatter<EventType>))]
    public EventType EventType { get; init; }

    /// <summary>
    ///     <see cref="EventIntent" /> is the original intent required to be subscribed to in order to receive
    ///     the event.
    /// </summary>
    [Key("eventIntent")]
    public int EventIntent { get; init; }

    [Key("eventData")] public object EventData { get; init; } = null!;
}