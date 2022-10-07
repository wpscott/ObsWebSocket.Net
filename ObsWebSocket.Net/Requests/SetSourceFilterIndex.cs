using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the index position of a filter on a source.
/// </summary>
[MessagePackObject]
public class SetSourceFilterIndex
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
    ///     <para>New index position of the filter</para>
    ///     <remarks>value &gt;= 0</remarks>
    /// </summary>
    [JsonPropertyName("filterIndex")]
    [Key("filterIndex")]
    public uint FilterIndex { get; init; }
}