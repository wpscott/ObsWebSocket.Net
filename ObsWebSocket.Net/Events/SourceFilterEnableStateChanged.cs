using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A source filter's enable state has changed.
/// </summary>
[MessagePackObject]
public struct SourceFilterEnableStateChanged
{
    /// <summary>
    ///     Name of the source the filter is on
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

    /// <summary>
    ///     Whether the filter is enabled
    /// </summary>
    [JsonPropertyName("filterEnabled")]
    [Key("filterEnabled")]
    public bool FilterEnabled { get; init; }
}