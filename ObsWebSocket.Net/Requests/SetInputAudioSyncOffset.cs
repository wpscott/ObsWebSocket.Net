using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the audio sync offset of an input.
/// </summary>
[MessagePackObject]
public struct SetInputAudioSyncOffset
{
    /// <summary>
    ///     Name of the input to set the audio sync offset of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     <para>New audio sync offset in milliseconds	</para>
    ///     <remarks>-950 &lt;= value &lt;= 20000</remarks>
    /// </summary>
    [JsonPropertyName("inputAudioSyncOffset")]
    [Key("inputAudioSyncOffset")]
    public int InputAudioSyncOffset { get; init; }
}