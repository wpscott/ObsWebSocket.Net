using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the enable state of a source filter.
/// </summary>
[MessagePackObject]
public class SetSourceFilterEnabled
{
    /// <summary>
    ///     Name of the source the filter is on
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
    ///     New enable state of the filter
    /// </summary>
    [JsonPropertyName("filterEnabled")]
    [Key("filterEnabled")]
    public bool FilterEnabled { get; init; }
}