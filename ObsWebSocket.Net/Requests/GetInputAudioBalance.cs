using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the audio balance of an input.
/// </summary>
[MessagePackObject]
public class GetInputAudioBalance
{
    /// <summary>
    ///     Name of the input to get the audio balance of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;
}

/// <summary>
///     Gets the audio balance of an input.
/// </summary>
[MessagePackObject]
public class GetInputAudioBalanceResponse
{
    /// <summary>
    ///     Audio balance value from 0.0-1.0
    /// </summary>
    [JsonPropertyName("inputAudioBalance")]
    [Key("inputAudioBalance")]
    public double InputAudioBalance { get; init; }
}