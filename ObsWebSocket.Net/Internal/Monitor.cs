using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Monitor
{
    [JsonPropertyName("monitorName")]
    [Key("monitorName")]
    public string MonitorName { get; init; } = null!;

    [JsonPropertyName("monitorIndex")]
    [Key("monitorIndex")]
    public int MonitorIndex { get; init; }

    [JsonPropertyName("monitorWidth")]
    [Key("monitorWidth")]
    public uint MonitorWidth { get; init; }

    [JsonPropertyName("monitorHeight")]
    [Key("monitorHeight")]
    public uint MonitorHeight { get; init; }

    [JsonPropertyName("monitorPositionX")]
    [Key("monitorPositionX")]
    public int MonitorPositionX { get; init; }

    [JsonPropertyName("monitorPositionY")]
    [Key("monitorPositionY")]
    public int MonitorPositionY { get; init; }
}