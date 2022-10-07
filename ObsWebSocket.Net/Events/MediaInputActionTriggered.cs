using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An action has been performed on an input.
/// </summary>
[MessagePackObject]
public class MediaInputActionTriggered
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Action performed on the input. See <see cref="ObsWebSocketMediaInputAction" /> enum
    /// </summary>
    [JsonPropertyName("mediaAction")]
    [Key("mediaAction")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsWebSocketMediaInputAction>))]
    public ObsWebSocketMediaInputAction WebSocketMediaInputAction { get; init; }
}