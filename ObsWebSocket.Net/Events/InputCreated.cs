using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     An input has been created.
/// </summary>
[MessagePackObject]
public struct InputCreated
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     The kind of the input
    /// </summary>
    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; }

    /// <summary>
    ///     The unversioned kind of input (aka no <c>_v2</c> stuff)
    /// </summary>
    [JsonPropertyName("unversionedInputKind")]
    [Key("unversionedInputKind")]
    public string UnversionedInputKind { get; init; }

    /// <summary>
    ///     The settings configured to the input when it was created
    /// </summary>
    [JsonPropertyName("inputSettings")]
    [Key("inputSettings")]
    public IReadOnlyDictionary<string, object> InputSettings { get; init; }

    /// <summary>
    ///     The default settings for the input
    /// </summary>
    [JsonPropertyName("defaultInputSettings")]
    [Key("defaultInputSettings")]
    public IReadOnlyDictionary<string, object> DefaultInputSettings { get; init; }
}