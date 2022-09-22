using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the enable state of audio tracks of an input.
/// </summary>
[MessagePackObject]
public struct SetInputAudioTracks
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Track settings to apply
    /// </summary>
    [JsonPropertyName("inputAudioTracks")]
    [Key("inputAudioTracks")]
    public IDictionary<string, bool> InputAudioTracks { get; init; }
}