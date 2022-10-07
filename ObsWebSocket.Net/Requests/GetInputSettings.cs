using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the settings of an input.</para>
///     <remarks>
///         Note: Does not include defaults. To create the entire settings object, overlay
///         <see cref="GetInputSettingsResponse.InputSettings" /> over the
///         <see cref="GetInputDefaultSettingsResponse.DefaultInputSettings" /> provided by
///         <see cref="GetInputDefaultSettings" />.
///     </remarks>
/// </summary>
[MessagePackObject]
public class GetInputSettings
{
    /// <summary>
    ///     Name of the input to get the settings of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;
}

/// <summary>
///     Gets the settings of an input.
/// </summary>
[MessagePackObject]
public class GetInputSettingsResponse
{
    /// <summary>
    ///     Object of settings for the input
    /// </summary>
    [JsonPropertyName("inputSettings")]
    [Key("inputSettings")]
    public IReadOnlyDictionary<string, object> InputSettings { get; init; } = null!;

    /// <summary>
    ///     The kind of the input
    /// </summary>
    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; } = null!;
}