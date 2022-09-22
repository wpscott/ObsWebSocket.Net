using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An input's mute state has changed.
/// </summary>
[MessagePackObject]
public struct InputMuteStateChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Whether the input is muted
    /// </summary>
    [JsonPropertyName("inputMuted")]
    [Key("inputMuted")]
    public bool InputMuted { get; init; }
}