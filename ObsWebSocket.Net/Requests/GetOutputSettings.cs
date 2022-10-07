using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the settings of an output.
/// </summary>
[MessagePackObject]
public class GetOutputSettings
{
    // <summary>
    /// Output name
    /// </summary>
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; } = null!;
}

/// <summary>
///     Gets the settings of an output.
/// </summary>
[MessagePackObject]
public class GetOutputSettingsResponse
{
    /// <summary>
    ///     Output settings
    /// </summary>
    [JsonPropertyName("outputSettings")]
    [Key("outputSettings")]
    public IReadOnlyDictionary<string, object> OutputSettings { get; init; } = null!;
}