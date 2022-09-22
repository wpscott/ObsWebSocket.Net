using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject()]
public struct GetSourcePrivateSettings
{
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }
}

[MessagePackObject()]
public struct GetSourcePrivateSettingsResponse
{
    [JsonPropertyName("sourceSettings")]
    [Key("sourceSettings")]
    public IReadOnlyDictionary<string, object> SourceSettings { get; init; }
}