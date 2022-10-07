using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Presses a button in the properties of an input.</para>
///     <para>Some known <see cref="PropertyName" /> values are:</para>
///     <para><c>refreshnocache</c> - Browser source reload button</para>
///     <remarks>
///         Note: Use this in cases where there is a button in the properties of an input that cannot be accessed in
///         any other way. For example, browser sources, where there is a refresh button.
///     </remarks>
/// </summary>
[MessagePackObject]
public class PressInputPropertiesButton
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    /// <summary>
    ///     Name of the button property to press
    /// </summary>
    [JsonPropertyName("propertyName")]
    [Key("propertyName")]
    public string PropertyName { get; init; } = null!;
}