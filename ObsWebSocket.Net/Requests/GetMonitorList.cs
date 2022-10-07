using System.Text.Json.Serialization;
using MessagePack;
using Monitor = ObsWebSocket.Net.Internal.Monitor;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets a list of connected monitors and information about them.
/// </summary>
[MessagePackObject]
public class GetMonitorListResponse
{
    /// <summary>
    ///     a list of detected monitors with some information
    /// </summary>
    [JsonPropertyName("monitors")]
    [Key("monitors")]
    public IReadOnlyList<Monitor> Monitors { get; init; } = null!;
}