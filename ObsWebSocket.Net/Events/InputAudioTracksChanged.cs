using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The audio tracks of an input have changed.
/// </summary>
[MessagePackObject]
public class InputAudioTracksChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Object of audio tracks along with their associated enable states
    /// </summary>
    [JsonPropertyName("inputAudioTracks")]
    [Key("inputAudioTracks")]
    public IReadOnlyDictionary<string, bool> InputAudioTracks { get; init; } = null!;
}