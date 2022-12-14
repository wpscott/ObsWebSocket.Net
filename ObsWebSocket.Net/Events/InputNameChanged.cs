using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The name of an input has changed.
/// </summary>
[MessagePackObject]
public class InputNameChanged
{
    /// <summary>
    ///     Old name of the input
    /// </summary>
    [JsonPropertyName("oldInputName")]
    [Key("oldInputName")]
    public string OldInputName { get; init; } = null!;

    /// <summary>
    ///     New name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;
}