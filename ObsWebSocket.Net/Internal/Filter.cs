using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Filter
{
    [JsonPropertyName("filterEnabled")]
    [Key("filterEnabled")]
    public bool FilterEnabled { get; init; }

    [JsonPropertyName("filterIndex")]
    [Key("filterIndex")]
    public int FilterIndex { get; init; }

    [JsonPropertyName("filterKind")]
    [Key("filterKind")]
    public string FilterKind { get; init; } = null!;

    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; } = null!;

    [JsonPropertyName("filterSettings")]
    [Key("filterSettings")]
    public IReadOnlyDictionary<string, object> FilterSettings { get; init; } = null!;
}