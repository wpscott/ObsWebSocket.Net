using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the audio monitor type of an input.
/// </summary>
[MessagePackObject]
public struct SetInputAudioMonitorType
{
    /// <summary>
    ///     Name of the input to set the audio monitor type of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Audio monitor type
    /// </summary>
    [JsonPropertyName("monitorType")]
    [Key("monitorType")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsMonitoringType>))]
    public ObsMonitoringType MonitorType { get; init; }
}