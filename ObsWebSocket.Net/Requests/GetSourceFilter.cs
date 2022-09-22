using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the info for a specific source filter.
/// </summary>
[MessagePackObject]
public struct GetSourceFilter
{
    /// <summary>
    ///     Name of the source
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    /// <summary>
    ///     Name of the filter
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; }
}

/// <summary>
///     Gets the info for a specific source filter.
/// </summary>
[MessagePackObject]
public struct GetSourceFilterResponse
{
    /// <summary>
    ///     Whether the filter is enabled
    /// </summary>
    [JsonPropertyName("filterEnabled")]
    [Key("filterEnabled")]
    public bool FilterEnabled { get; init; }

    /// <summary>
    ///     Index of the filter in the list, beginning at 0
    /// </summary>
    [JsonPropertyName("filterIndex")]
    [Key("filterIndex")]
    public int FilterIndex { get; init; }

    /// <summary>
    ///     The kind of filter
    /// </summary>
    [JsonPropertyName("filterKind")]
    [Key("filterKind")]
    public string FilterKind { get; init; }

    /// <summary>
    ///     Settings object associated with the filter
    /// </summary>
    [JsonPropertyName("filterSettings")]
    [Key("filterSettings")]
    public IReadOnlyDictionary<string, object> FilterSettings { get; init; }
}