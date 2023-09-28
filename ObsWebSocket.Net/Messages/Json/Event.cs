using System.Text.Json;
using System.Text.Json.Serialization;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages.Json;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: All subscribed and identified clients</para>
///     <para>Description: An event coming from OBS has occured. Eg scene switched, source muted.</para>
/// </summary>
public class Event
{
    [JsonPropertyName("eventType")] public EventType EventType { get; init; }

    /// <summary>
    ///     <see cref="EventIntent" /> is the original intent required to be subscribed to in order to receive
    ///     the event.
    /// </summary>
    [JsonPropertyName("eventIntent")]
    public int EventIntent { get; init; }

    [JsonPropertyName("eventData")] public JsonDocument EventData { get; init; } = null!;
}