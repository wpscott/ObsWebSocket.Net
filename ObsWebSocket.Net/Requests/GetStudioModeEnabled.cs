using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class GetStudioModeEnabledResponse
{
    [JsonPropertyName("studioModeEnabled")]
    [Key("studioModeEnabled")]
    public bool StudioModeEnabled { get; init; }
}