using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class GetSourcePrivateSettings
{
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;
}

[MessagePackObject]
public class GetSourcePrivateSettingsResponse
{
    [JsonPropertyName("sourceSettings")]
    [Key("sourceSettings")]
    public IReadOnlyDictionary<string, object> SourceSettings { get; init; } = null!;
}