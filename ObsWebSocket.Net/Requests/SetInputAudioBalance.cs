using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the audio balance of an input.
/// </summary>
[MessagePackObject]
public class SetInputAudioBalance
{
    /// <summary>
    ///     Name of the input to get the audio balance of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     <para>New audio balance value	</para>
    ///     <remarks>0.0 &lt;= value &lt;= 1.0</remarks>
    /// </summary>
    [JsonPropertyName("inputAudioBalance")]
    [Key("inputAudioBalance")]
    public float InputAudioBalance { get; init; }
}