using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     <para>An event has been emitted from a vendor.</para>
///     <para>
///         A vendor is a unique name registered by a third-party plugin or script, which allows for custom requests and
///         events to be added to obs-websocket. If a plugin or script implements vendor requests or events, documentation
///         is expected to be provided with them.
///     </para>
/// </summary>
[MessagePackObject]
public struct VendorEvent
{
    /// <summary>
    ///     Name of the vendor emitting the event
    /// </summary>
    [JsonPropertyName("vendorName")]
    [Key("vendorName")]
    public string VendorName { get; init; }

    /// <summary>
    ///     Vendor-provided event typedef
    /// </summary>
    [JsonPropertyName("eventType")]
    [Key("eventType")]
    public string EventType { get; init; }

    /// <summary>
    ///     Vendor-provided event data. {} if event does not provide any data
    /// </summary>
    [JsonPropertyName("eventData")]
    [Key("eventData")]
    public IReadOnlyDictionary<string, object> EventData { get; init; }
}