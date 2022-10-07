using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets data about the current plugin and RPC version.
/// </summary>
[MessagePackObject]
public class GetVersionResponse
{
    /// <summary>
    ///     Current OBS Studio version
    /// </summary>
    [JsonPropertyName("obsVersion")]
    [Key("obsVersion")]
    public string ObsVersion { get; init; } = null!;

    /// <summary>
    ///     Current obs-websocket version
    /// </summary>
    [JsonPropertyName("obsWebSocketVersion")]
    [Key("obsWebSocketVersion")]
    public string ObsWebSocketVersion { get; init; } = null!;

    /// <summary>
    ///     Current latest obs-websocket RPC version
    /// </summary>
    [JsonPropertyName("rpcVersion")]
    [Key("rpcVersion")]
    public int RpcVersion { get; init; }

    /// <summary>
    ///     Array of available RPC requests for the currently negotiated RPC version
    /// </summary>
    [JsonPropertyName("availableRequests")]
    [Key("availableRequests")]
    public IReadOnlyList<string> AvailableRequests { get; init; } = null!;

    /// <summary>
    ///     Image formats available in <see cref="GetSourceScreenshot" /> and <see cref="SaveSourceScreenshot" /> requests.
    /// </summary>
    [JsonPropertyName("supportedImageFormats")]
    [Key("supportedImageFormats")]
    public IReadOnlyList<string> SupportedImageFormats { get; init; } = null!;

    /// <summary>
    ///     Name of the platform. Usually <c>windows</c>, <c>macos</c>, or <c>ubuntu</c> (linux flavor). Not guaranteed to be
    ///     any of those
    /// </summary>
    [JsonPropertyName("platform")]
    [Key("platform")]
    public string Platform { get; init; } = null!;

    /// <summary>
    ///     Description of the platform, like <c>Windows 10 (10.0)</c>
    /// </summary>
    [JsonPropertyName("platformDescription")]
    [Key("platformDescription")]
    public string PlatformDescription { get; init; } = null!;
}