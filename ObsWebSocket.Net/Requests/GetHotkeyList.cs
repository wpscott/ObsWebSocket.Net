using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all hotkey names in OBS
/// </summary>
[MessagePackObject]
public class GetHotkeyListResponse
{
    /// <summary>
    ///     Array of hotkey names
    /// </summary>
    [JsonPropertyName("hotkeys")]
    [Key("hotkeys")]
    public IReadOnlyList<string> Hotkeys { get; init; } = null!;
}