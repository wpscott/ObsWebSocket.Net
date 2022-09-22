using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ObsWebSocketDataRealm : byte
{
    OBS_WEBSOCKET_DATA_REALM_GLOBAL,
    OBS_WEBSOCKET_DATA_REALM_PROFILE
}