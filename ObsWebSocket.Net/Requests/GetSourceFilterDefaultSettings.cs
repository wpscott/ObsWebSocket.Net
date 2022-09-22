using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the default settings for a filter kind.
/// </summary>
[MessagePackObject]
public struct GetSourceFilterDefaultSettings
{
    /// <summary>
    ///     Filter kind to get the default settings for
    /// </summary>
    [JsonPropertyName("filterKind")]
    [Key("filterKind")]
    public string FilterKind { get; init; }
}

/// <summary>
///     Gets the default settings for a filter kind.
/// </summary>
[MessagePackObject]
public struct GetSourceFilterDefaultSettingsResponse
{
    /// <summary>
    ///     Object of default settings for the filter kind
    /// </summary>
    [JsonPropertyName("defaultFilterSettings")]
    [Key("defaultFilterSettings")]
    public IReadOnlyDictionary<string, object> DefaultFilterSettings { get; init; }
}