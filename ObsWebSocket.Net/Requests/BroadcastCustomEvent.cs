using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Broadcasts a <c>CustomEvent</c> to all WebSocket clients. Receivers are clients which are identified and
///     subscribed.
/// </summary>
[MessagePackObject]
public class BroadcastCustomEvent
{
    /// <summary>
    ///     Data payload to emit to all receivers
    /// </summary>
    [JsonPropertyName("eventData")]
    [Key("eventData")]
    public IDictionary<string, object> EventData { get; init; } = null!;
}