using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all of a source's filters.
/// </summary>
[MessagePackObject]
public struct GetSourceFilterList
{
    /// <summary>
    ///     Name of the source
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }
}

/// <summary>
///     Gets an array of all of a source's filters.
/// </summary>
[MessagePackObject]
public struct GetSourceFilterListResponse
{
    /// <summary>
    ///     Array of filters
    /// </summary>
    [JsonPropertyName("filters")]
    [Key("filters")]
    public IReadOnlyList<Filter> Filters { get; init; }
}