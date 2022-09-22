using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the current stream service settings (stream destination).
/// </summary>
[MessagePackObject]
public struct GetStreamServiceSettingsResponse
{
    /// <summary>
    ///     Stream service type, like <c>rtmp_custom</c> or <c>rtmp_common</c>
    /// </summary>
    [JsonPropertyName("streamServiceType")]
    [Key("streamServiceType")]
    public string StreamServiceType { get; init; }

    /// <summary>
    ///     Stream service settings
    /// </summary>
    [JsonPropertyName("streamServiceSettings")]
    [Key("streamServiceSettings")]
    public IReadOnlyDictionary<string, object> StreamServiceSettings { get; init; }
}