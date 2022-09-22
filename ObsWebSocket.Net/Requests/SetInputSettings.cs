using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the settings of an input.
/// </summary>
[MessagePackObject]
public struct SetInputSettings
{
    /// <summary>
    ///     Name of the input to set the settings of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Object of settings to apply
    /// </summary>
    [JsonPropertyName("inputSettings")]
    [Key("inputSettings")]
    public IDictionary<string, object> InputSettings { get; init; }

    /// <summary>
    ///     <see langword="true" /> == apply the settings on top of existing ones, <see langword="false" /> == reset the input to its defaults, then
    ///     apply settings.
    /// </summary>
    [JsonPropertyName("overlay")]
    [Key("overlay")]
    public bool? Overlay { get; init; }
}