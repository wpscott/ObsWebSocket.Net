using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Opens a projector for a specific output video mix.</para>
///     <para>Mix types: <see cref="ObsWebSocketVideoMixType" /></para>
///     <remarks>
///         Note: This request serves to provide feature parity with 4.x. It is very likely to be changed/deprecated
///         in a future release.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct OpenVideoMixProjector
{
    /// <summary>
    ///     Type of mix to open
    /// </summary>
    [JsonPropertyName("videoMixType")]
    [Key("videoMixType")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsWebSocketVideoMixType>))]
    public ObsWebSocketVideoMixType VideoMixType { get; init; }

    /// <summary>
    ///     Monitor index, use <see cref="RequestType.GetMonitorList" /> to obtain index
    /// </summary>
    [JsonPropertyName("monitorIndex")]
    [Key("monitorIndex")]
    public int? MonitorIndex { get; init; }

    /// <summary>
    ///     Size/Position data for a windowed projector, in Qt Base64 encoded format. Mutually exclusive with
    ///     <see cref="MonitorIndex" />
    /// </summary>
    [JsonPropertyName("projectorGeometry")]
    [Key("projectorGeometry")]
    public string? ProjectorGeometry { get; init; }
}