using MessagePack;
using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject()]
public struct SetSourcePrivateSettings
{
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    [JsonPropertyName("sourceSettings")]
    [Key("sourceSettings")]
    public IDictionary<string, object> SourceSettings { get; init; }
}