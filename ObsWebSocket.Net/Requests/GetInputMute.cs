using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the audio mute state of an input.
/// </summary>
[MessagePackObject]
public struct GetInputMute
{
    /// <summary>
    ///     Name of input to get the mute state of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the audio mute state of an input.
/// </summary>
[MessagePackObject]
public struct GetInputMuteResponse
{
    /// <summary>
    ///     Whether the input is muted
    /// </summary>
    [JsonPropertyName("inputMuted")]
    [Key("inputMuted")]
    public bool InputMuted { get; init; }
}