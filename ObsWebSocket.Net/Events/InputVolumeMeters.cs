using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A high-volume event providing volume levels of all active inputs every 50 milliseconds.
/// </summary>
[MessagePackObject]
public class InputVolumeMeters
{
    /// <summary>
    ///     Array of active inputs with their associated volume levels
    /// </summary>
    [JsonPropertyName("inputs")]
    [Key("inputs")]
    public IReadOnlyList<IReadOnlyDictionary<string, object>> Inputs { get; init; } = null!;
}