using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The name of a source filter has changed.
/// </summary>
[MessagePackObject]
public class SourceFilterNameChanged
{
    /// <summary>
    ///     The source the filter is on
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    /// </summary>
    [JsonPropertyName("oldFilterName")]
    [Key("oldFilterName")]
    public string OldFilterName { get; init; } = null!;

    /// <summary>
    ///     New name of the filter
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; } = null!;
}