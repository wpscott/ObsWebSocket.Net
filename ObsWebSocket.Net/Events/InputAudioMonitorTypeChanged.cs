using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The monitor type of an input has changed.
/// </summary>
[MessagePackObject]
public class InputAudioMonitorTypeChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     See <see cref="ObsMonitoringType" /> enum
    /// </summary>
    [JsonPropertyName("monitorType")]
    [Key("monitorType")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsMonitoringType>))]
    public ObsMonitoringType MonitorType { get; init; }
}