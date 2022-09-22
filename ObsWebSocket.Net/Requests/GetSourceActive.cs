using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the active and show state of a source.</para>
///     <remarks>Compatible with inputs and scenes.</remarks>
/// </summary>
[MessagePackObject]
public struct GetSourceActive
{
    /// <summary>
    ///     Name of the source to get the active state of
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }
}

/// <summary>
///     Gets the active and show state of a source.
/// </summary>
[MessagePackObject]
public struct GetSourceActiveResponse
{
    /// <summary>
    ///     Whether the source is showing in Program
    /// </summary>
    [JsonPropertyName("videoActive")]
    [Key("videoActive")]
    public bool VideoActive { get; init; }

    /// <summary>
    ///     Whether the source is showing in the UI (Preview, Projector, Properties)
    /// </summary>
    [JsonPropertyName("videoShowing")]
    [Key("videoShowing")]
    public bool VideoShowing { get; init; }
}