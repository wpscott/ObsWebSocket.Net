using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the cursor position of the current scene transition.
/// </summary>
[MessagePackObject]
public struct GetCurrentSceneTransitionCursorResponse
{
    /// <summary>
    ///     Cursor position, between 0.0 and 1.0
    /// </summary>
    [JsonPropertyName("transitionCursor")]
    [Key("transitionCursor")]
    public double TransitionCursor { get; init; }
}