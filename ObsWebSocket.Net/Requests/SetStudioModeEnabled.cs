using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Enables or disables studio mode
/// </summary>
[MessagePackObject]
public class SetStudioModeEnabled
{
    /// <summary>
    ///     <see langword="true" /> == Enabled, <see langword="false" /> == Disabled
    /// </summary>
    [JsonPropertyName("studioModeEnabled")]
    [Key("studioModeEnabled")]
    public bool StudioModeEnabled { get; init; }
}