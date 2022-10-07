using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the settings of a source filter.
/// </summary>
[MessagePackObject]
public class SetSourceFilterSettings
{
    /// <summary>
    ///     Name of the source the filter is on
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Name of the filter to set the settings of
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; } = null!;

    /// <summary>
    ///     Object of settings to apply
    /// </summary>
    [JsonPropertyName("filterSettings")]
    [Key("filterSettings")]
    public IDictionary<string, object> FilterSettings { get; init; } = null!;

    /// <summary>
    ///     <see langword="true" /> == apply the settings on top of existing ones, <see langword="false" /> == reset the input
    ///     to its defaults, then
    ///     apply settings.
    /// </summary>
    [JsonPropertyName("overlay")]
    [Key("overlay")]
    public bool? Overlay { get; init; }
}