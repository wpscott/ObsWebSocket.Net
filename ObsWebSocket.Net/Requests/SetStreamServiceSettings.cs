using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the current stream service settings (stream destination).</para>
///     <remarks>
///         Note: Simple RTMP settings can be set with type <c>rtmp_custom</c> and the settings fields <c>server</c>
///         and <c>key</c>.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct SetStreamServiceSettings
{
    /// <summary>
    ///     Type of stream service to apply. Example: <c>rtmp_custom</c> or <c>rtmp_common</c>
    /// </summary>
    [JsonPropertyName("streamServiceType")]
    [Key("streamServiceType")]
    public string StreamServiceType { get; init; }

    /// <summary>
    ///     Settings to apply to the service
    /// </summary>
    [JsonPropertyName("streamServiceSettings")]
    [Key("streamServiceSettings")]
    public IDictionary<string, object> StreamServiceSettings { get; init; }
}