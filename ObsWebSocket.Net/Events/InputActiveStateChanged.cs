using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An input's active state has changed.
///     <para>When an input is active, it means it's being shown by the program feed.</para>
/// </summary>
[MessagePackObject]
public struct InputActiveStateChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Whether the input is active
    /// </summary>
    [JsonPropertyName("videoActive")]
    [Key("videoActive")]
    public bool VideoActive { get; init; }
}