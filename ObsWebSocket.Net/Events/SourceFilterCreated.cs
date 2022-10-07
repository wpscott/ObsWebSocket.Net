using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A filter has been added to a source.
/// </summary>
[MessagePackObject]
public class SourceFilterCreated
{
    /// <summary>
    ///     Name of the source the filter was added to
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Name of the filter
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; } = null!;

    /// <summary>
    ///     The kind of the filter
    /// </summary>
    [JsonPropertyName("filterKind")]
    [Key("filterKind")]
    public string FilterKind { get; init; } = null!;

    /// <summary>
    ///     Index position of the filter
    /// </summary>
    [JsonPropertyName("filterIndex")]
    [Key("filterIndex")]
    public int FilterIndex { get; init; }

    /// <summary>
    ///     The settings configured to the filter when it was created
    /// </summary>
    [JsonPropertyName("filterSettings")]
    [Key("filterSettings")]
    public IReadOnlyDictionary<string, object> FilterSettings { get; init; } = null!;

    /// <summary>
    ///     The default settings for the filter
    /// </summary>
    [JsonPropertyName("defaultFilterSettings")]
    [Key("defaultFilterSettings")]
    public IReadOnlyDictionary<string, object> DefaultFilterSettings { get; init; } = null!;
}