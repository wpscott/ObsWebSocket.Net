using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the enable state of all audio tracks of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioTracks
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the enable state of all audio tracks of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioTracksResponse
{
    /// <summary>
    ///     Object of audio tracks and associated enable states
    /// </summary>
    [JsonPropertyName("inputAudioTracks")]
    [Key("inputAudioTracks")]
    public IReadOnlyDictionary<string, bool> InputAudioTracks { get; init; }
}