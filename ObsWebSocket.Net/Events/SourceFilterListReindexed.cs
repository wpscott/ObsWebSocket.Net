using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A source's filter list has been reindexed.
/// </summary>
[MessagePackObject]
public class SourceFilterListReindexed
{
    /// <summary>
    ///     Name of the source
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Array of filter objects
    /// </summary>
    [JsonPropertyName("filters")]
    [Key("filters")]
    public IReadOnlyList<Filter> Filters { get; init; } = null!;
}