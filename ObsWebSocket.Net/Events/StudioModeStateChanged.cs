using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     Studio mode has been enabled or disabled.
/// </summary>
[MessagePackObject]
public struct StudioModeStateChanged
{
    /// <summary>
    ///     True == Enabled, False == Disabled
    /// </summary>
    [JsonPropertyName("studioModeEnabled")]
    [Key("studioModeEnabled")]
    public bool StudioModeEnabled { get; init; }
}