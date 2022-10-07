using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the audio mute state of an input.
/// </summary>
[MessagePackObject]
public class SetInputMute
{
    /// <summary>
    ///     Name of the input to set the mute state of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Whether to mute the input or not
    /// </summary>
    [JsonPropertyName("inputMuted")]
    [Key("inputMuted")]
    public bool InputMuted { get; init; }
}