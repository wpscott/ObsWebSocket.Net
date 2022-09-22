using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Offsets the current cursor position of a media input by the specified value.</para>
///     <remarks>This request does not perform bounds checking of the cursor position.</remarks>
/// </summary>
[MessagePackObject]
public struct OffsetMediaInputCursor
{
    /// <summary>
    ///     Name of the media input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Value to offset the current cursor position by
    /// </summary>
    [JsonPropertyName("mediaCursorOffset")]
    [Key("mediaCursorOffset")]
    public long MediaCursor { get; init; }
}