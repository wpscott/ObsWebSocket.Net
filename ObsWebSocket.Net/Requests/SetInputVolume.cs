using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the volume setting of an input.
/// </summary>
[MessagePackObject]
public class SetInputVolume
{
    /// <summary>
    ///     Name of the input to get the volume of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     <para>Volume setting in mul</para>
    ///     <remarks>0 &lt;= value &lt;= 20</remarks>
    /// </summary>
    [JsonPropertyName("inputVolumeMul")]
    [Key("inputVolumeMul")]
    public float InputVolumeMul { get; init; }

    /// <summary>
    ///     <para>Volume setting in dB</para>
    ///     <remarks>-100 &lt;= value &lt;= 26</remarks>
    /// </summary>
    [JsonPropertyName("inputVolumeDb")]
    [Key("inputVolumeDb")]
    public float InputVolumeDb { get; init; }
}