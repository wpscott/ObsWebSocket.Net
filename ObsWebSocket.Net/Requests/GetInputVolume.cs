using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the current volume setting of an input.
/// </summary>
[MessagePackObject]
public struct GetInputVolume
{
    /// <summary>
    ///     Name of the input to get the volume of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the current volume setting of an input.
/// </summary>
[MessagePackObject]
public struct GetInputVolumeResponse
{
    /// <summary>
    ///     Volume setting in mul
    /// </summary>
    [JsonPropertyName("inputVolumeMul")]
    [Key("inputVolumeMul")]
    public double InputVolumeMul { get; init; }

    /// <summary>
    ///     Volume setting in dB
    /// </summary>
    [JsonPropertyName("inputVolumeDb")]
    [Key("inputVolumeDb")]
    public double InputVolumeDb { get; init; }
}