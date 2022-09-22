using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The audio balance value of an input has changed.
/// </summary>
[MessagePackObject]
public struct InputAudioBalanceChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     New audio balance value of the input
    /// </summary>
    [JsonPropertyName("inputAudioBalance")]
    [Key("inputAudioBalance")]
    public double InputAudioBalance { get; init; }
}