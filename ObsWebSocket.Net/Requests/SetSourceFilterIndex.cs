using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the index position of a filter on a source.
/// </summary>
[MessagePackObject]
public struct SetSourceFilterIndex
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
    ///     <para>New index position of the filter</para>
    ///     <remarks>value &gt;= 0</remarks>
    /// </summary>
    [JsonPropertyName("filterIndex")]
    [Key("filterIndex")]
    public uint FilterIndex { get; init; }
}