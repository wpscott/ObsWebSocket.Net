using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ObsWebSocketVideoMixType : byte
{
    OBS_WEBSOCKET_VIDEO_MIX_TYPE_PREVIEW,
    OBS_WEBSOCKET_VIDEO_MIX_TYPE_PROGRAM,
    OBS_WEBSOCKET_VIDEO_MIX_TYPE_MULTIVIEW
}