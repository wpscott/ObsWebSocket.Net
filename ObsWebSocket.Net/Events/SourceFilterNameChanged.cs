using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The name of a source filter has changed.
/// </summary>
[MessagePackObject]
public struct SourceFilterNameChanged
{
    /// <summary>
    ///     The source the filter is on
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("oldFilterName")]
    [Key("oldFilterName")]
    public string OldFilterName { get; init; }

    /// <summary>
    ///     New name of the filter
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; }
}