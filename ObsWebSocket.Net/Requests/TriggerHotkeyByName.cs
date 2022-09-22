using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Triggers a hotkey using its name. See GetHotkeyList
/// </summary>
[MessagePackObject]
public struct TriggerHotkeyByName
{
    /// <summary>
    ///     Name of the hotkey to trigger
    /// </summary>
    [JsonPropertyName("hotkeyName")]
    [Key("hotkeyName")]
    public string HotkeyName { get; init; }
}