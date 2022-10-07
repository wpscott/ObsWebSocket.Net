using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Toggles the status of the stream output.
/// </summary>
[MessagePackObject]
public class ToggleStreamResponse
{
    /// <summary>
    ///     New state of the stream output
    /// </summary>
    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }
}