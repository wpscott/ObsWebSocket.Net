using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A filter has been removed from a source.
/// </summary>
[MessagePackObject]
public class SourceFilterRemoved
{
    /// <summary>
    ///     Name of the source the filter was on
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
}