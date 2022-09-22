namespace ObsWebSocket.Net.Enums.Obs;

[Flags]
public enum ObsOutputFlags : byte
{
    OBS_OUTPUT_VIDEO = 1 << 0,
    OBS_OUTPUT_AUDIO = 1 << 1,
    OBS_OUTPUT_AV = OBS_OUTPUT_VIDEO | OBS_OUTPUT_AUDIO,
    OBS_OUTPUT_ENCODED = 1 << 2,
    OBS_OUTPUT_SERVICE = 1 << 3,
    OBS_OUTPUT_MULTI_TRACK = 1 << 4,
    OBS_OUTPUT_CAN_PAUSE = 1 << 5
}