using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Triggers a hotkey using a sequence of keys.
/// </summary>
[MessagePackObject]
public struct TriggerHotkeyByKeySequence
{
    /// <summary>
    ///     The OBS key ID to use. See <see href="https://github.com/obsproject/obs-studio/blob/master/libobs/obs-hotkeys.h" />
    /// </summary>
    [JsonPropertyName("keyId")]
    [Key("keyId")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsHotKeys>))]
    public ObsHotKeys? KeyId { get; init; }

    /// <summary>
    ///     Object containing key modifiers to apply
    /// </summary>
    [JsonPropertyName("keyModifiers")]
    [Key("keyModifiers")]
    public KeyModifier? KeyModifiers { get; init; }
}

[MessagePackObject]
public struct KeyModifier
{
    /// <summary>
    ///     Press Shift
    /// </summary>
    [JsonPropertyName("shift")]
    [Key("shift")]
    public bool? Shift { get; init; }

    /// <summary>
    ///     Press CTRL
    /// </summary>
    [JsonPropertyName("control")]
    [Key("control")]
    public bool? Control { get; init; }

    /// <summary>
    ///     Press ALT
    /// </summary>
    [JsonPropertyName("Alt")]
    [Key("Alt")]
    public bool? Alt { get; init; }

    /// <summary>
    ///     Press CMD (Mac)
    /// </summary>
    [JsonPropertyName("command")]
    [Key("command")]
    public bool? Command { get; init; }
}