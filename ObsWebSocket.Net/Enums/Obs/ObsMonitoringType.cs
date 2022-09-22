using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Enums.Obs;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ObsMonitoringType : byte
{
    OBS_MONITORING_TYPE_NONE,
    OBS_MONITORING_TYPE_MONITOR_ONLY,
    OBS_MONITORING_TYPE_MONITOR_AND_OUTPUT
}