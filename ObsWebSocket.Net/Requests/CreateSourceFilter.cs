using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Creates a new filter, adding it to the specified source.
/// </summary>
[MessagePackObject]
public class CreateSourceFilter
{
    /// <summary>
    ///     Name of the source to add the filter to
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; } = null!;

    /// <summary>
    ///     Name of the new filter to be created
    /// </summary>
    [JsonPropertyName("filterName")]
    [Key("filterName")]
    public string FilterName { get; init; } = null!;

    /// <summary>
    ///     The kind of filter to be created
    /// </summary>
    [JsonPropertyName("filterKind")]
    [Key("filterKind")]
    public string FilterKind { get; init; } = null!;

    /// <summary>
    ///     Settings object to initialize the filter with
    /// </summary>
    [JsonPropertyName("filterSettings")]
    [Key("filterSettings")]
    public IDictionary<string, object>? FilterSettings { get; init; }
}