using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The sync offset of an input has changed.
/// </summary>
[MessagePackObject]
public struct InputAudioSyncOffsetChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     New sync offset in milliseconds
    /// </summary>
    [JsonPropertyName("inputAudioSyncOffset")]
    [Key("inputAudioSyncOffset")]
    public ulong InputAudioSyncOffset { get; init; }
}