using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The state of the virtualcam output has changed.
/// </summary>
[MessagePackObject]
public struct VirtualcamStateChanged
{
    /// <summary>
    ///     Whether the output is active
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }

    /// <summary>
    ///     The specific state of the output
    /// </summary>
    [JsonPropertyName("outputState")]
    [Key("outputState")]
    public string OutputState { get; init; }
}