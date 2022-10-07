using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the cursor position of a media input.</para>
///     <remarks>This request does not perform bounds checking of the cursor position.</remarks>
/// </summary>
[MessagePackObject]
public class SetMediaInputCursor
{
    /// <summary>
    ///     Name of the media input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     New cursor position to set
    /// </summary>
    [JsonPropertyName("mediaCursor")]
    [Key("mediaCursor")]
    public ulong MediaCursor { get; init; }
}