using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sends CEA-608 caption text over the stream output.
/// </summary>
[MessagePackObject]
public struct SendStreamCaption
{
    /// <summary>
    ///     Caption text
    /// </summary>
    [JsonPropertyName("captionText")]
    [Key("captionText")]
    public string CaptionText { get; init; }
}