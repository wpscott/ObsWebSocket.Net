using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An input's show state has changed.
///     <para>When an input is showing, it means it's being shown by the preview or a dialog.</para>
/// </summary>
[MessagePackObject]
public class InputShowStateChanged
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Whether the input is showing
    /// </summary>
    [JsonPropertyName("videoShowing")]
    [Key("videoShowing")]
    public bool VideoShowing { get; init; }
}