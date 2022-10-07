using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An input's volume level has changed.
/// </summary>
[MessagePackObject]
public class InputVolumeChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     New volume level in multimap
    /// </summary>
    [JsonPropertyName("inputVolumeMul")]
    [Key("inputVolumeMul")]
    public double InputVolumeMul { get; init; }

    /// <summary>
    ///     New volume level in dB
    /// </summary>
    [JsonPropertyName("inputVolumeDb")]
    [Key("inputVolumeDb")]
    public double InputVolumeDb { get; init; }
}