using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class SetSourcePrivateSettings
{
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    [JsonPropertyName("sourceSettings")]
    [Key("sourceSettings")]
    public IDictionary<string, object> SourceSettings { get; init; } = null!;
}