using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     <para>Sent from: Freshly connected websocket client</para>
///     <para>Sent to: obs-websocket</para>
///     <para>
///         Description: Response to <see cref="Hello" /> message, should contain authentication string if
///         authentication is required, along with PubSub subscriptions and other session parameters.
///     </para>
/// </summary>
[MessagePackObject]
public class Identify
{
    /// <summary>
    ///     <see cref="RpcVersion" /> is the version number that the client would like the obs-websocket server
    ///     to use.
    /// </summary>
    [JsonPropertyName("rpcVersion")]
    [Key("rpcVersion")]
    public int RpcVersion { get; init; }

    [JsonPropertyName("authentication")]
    [Key("authentication")]
    public string? Authentication { get; init; }

    /// <summary>
    ///     <see cref="EventSubscriptions" /> is a bitmask of
    ///     <see cref="Enums.EventSubscriptions" /> items to subscribe to events and event categories at
    ///     will. By default, all event categories are subscribed, except for events marked as high volume. High volume events
    ///     must be explicitly subscribed to.
    /// </summary>
    [JsonPropertyName("eventSubscriptions")]
    [Key("eventSubscriptions")]
    public EventSubscriptions EventSubscriptions { get; init; }
}