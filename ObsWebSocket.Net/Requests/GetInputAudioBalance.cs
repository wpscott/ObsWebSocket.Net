using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the audio balance of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioBalance
{
    /// <summary>
    ///     Name of the input to get the audio balance of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}

/// <summary>
///     Gets the audio balance of an input.
/// </summary>
[MessagePackObject]
public struct GetInputAudioBalanceResponse
{
    /// <summary>
    ///     Audio balance value from 0.0-1.0
    /// </summary>
    [JsonPropertyName("inputAudioBalance")]
    [Key("inputAudioBalance")]
    public double InputAudioBalance { get; init; }
}