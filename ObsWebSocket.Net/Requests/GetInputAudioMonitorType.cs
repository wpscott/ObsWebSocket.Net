using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the audio monitor type of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioMonitorType
{
    /// <summary>
    ///     Name of the input to get the audio monitor type of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the audio monitor type of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioMonitorTypeResponse
{
    /// <summary>
    ///     Audio monitor type
    /// </summary>
    [JsonPropertyName("monitorType")]
    [Key("monitorType")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsMonitoringType>))]
    public ObsMonitoringType MonitorType { get; init; }
}