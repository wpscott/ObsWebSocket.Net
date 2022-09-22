using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Toggles the audio mute state of an input.
/// </summary>
[MessagePackObject]
public struct ToggleInputMute
{
    /// <summary>
    ///     Name of input to get the mute state of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Toggles the audio mute state of an input.
/// </summary>
[MessagePackObject]
public struct ToggleInputMuteResponse
{
    /// <summary>
    ///     Whether the input has been muted or unmuted
    /// </summary>
    [JsonPropertyName("inputMuted")]
    [Key("inputMuted")]
    public bool InputMuted { get; init; }
}