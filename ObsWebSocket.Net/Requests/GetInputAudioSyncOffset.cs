using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the audio sync offset of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioSyncOffset
{
    /// <summary>
    ///     Name of the input to get the audio sync offset of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the audio sync offset of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioSyncOffsetResponse
{
    /// <summary>
    ///     Audio sync offset in milliseconds
    /// </summary>
    [JsonPropertyName("inputAudioSyncOffset")]
    [Key("inputAudioSyncOffset")]
    public long InputAudioSyncOffset { get; init; }
}