using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the name of a source filter (rename).
/// </summary>
[MessagePackObject]
public struct SetSourceFilterName
{
    /// <summary>
    ///     Name of the source the filter is on
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    /// <summary>
    ///     Current name of the filter
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; }

    /// <summary>
    ///     New name for the filter
    /// </summary>
    [JsonPropertyName("newFilterName")]
    [Key("newFilterName")]
    public string NewFilterName { get; init; }
}