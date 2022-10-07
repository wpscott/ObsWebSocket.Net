using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Triggers an action on a media input.
/// </summary>
[MessagePackObject]
public class TriggerMediaInputAction
{
    /// <summary>
    ///     Name of the media input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Identifier of the <see cref="ObsWebSocketMediaInputAction" /> enum
    /// </summary>
    [JsonPropertyName("mediaAction")]
    [Key("mediaAction")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsWebSocketMediaInputAction>))]
    public ObsWebSocketMediaInputAction MediaAction { get; init; }
}