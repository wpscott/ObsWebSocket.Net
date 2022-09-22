using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the default settings for an input kind.
/// </summary>
[MessagePackObject]
public struct GetInputDefaultSettings
{
    /// <summary>
    ///     Input kind to get the default settings for
    /// </summary>
    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; }
}

/// <summary>
///     Gets the default settings for an input kind.
/// </summary>
[MessagePackObject]
public struct GetInputDefaultSettingsResponse
{
    /// <summary>
    ///     Object of default settings for the input kind
    /// </summary>
    [JsonPropertyName("defaultInputSettings")]
    [Key("defaultInputSettings")]
    public IReadOnlyDictionary<string, object> DefaultInputSettings { get; init; }
}