using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all of a source's filters.
/// </summary>
[MessagePackObject]
public class GetSourceFilterList
{
    /// <summary>
    ///     Name of the source
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;
}

/// <summary>
///     Gets an array of all of a source's filters.
/// </summary>
[MessagePackObject]
public class GetSourceFilterListResponse
{
    /// <summary>
    ///     Array of filters
    /// </summary>
    [JsonPropertyName("filters")]
    [Key("filters")]
    public IReadOnlyList<Filter> Filters { get; init; } = null!;
}