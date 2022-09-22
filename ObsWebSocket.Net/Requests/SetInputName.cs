using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the name of an input (rename).
/// </summary>
[MessagePackObject]
public struct SetInputName
{
    /// <summary>
    ///     Current input name
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     New name for the input
    /// </summary>
    [JsonPropertyName("newInputName")]
    [Key("newInputName")]
    public string NewInputName { get; init; }
}