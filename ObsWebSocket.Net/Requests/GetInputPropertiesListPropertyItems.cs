using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the items of a list property from an input's properties.</para>
///     <remarks>
///         Note: Use this in cases where an input provides a dynamic, selectable list of items. For example, display
///         capture, where it provides a list of available displays.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct GetInputPropertiesListPropertyItems
{
    /// <summary>
    ///     Name of the input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     Name of the list property to get the items of
    /// </summary>
    [JsonPropertyName("propertyName")]
    [Key("propertyName")]
    public string PropertyName { get; init; }
}

/// <summary>
///     Gets the items of a list property from an input's properties.
/// </summary>
[MessagePackObject]
public struct GetInputPropertiesListPropertyItemsResponse
{
    /// <summary>
    ///     Array of items in the list property
    /// </summary>
    [JsonPropertyName("propertyItems")]
    [Key("propertyItems")]
    public IReadOnlyList<InputPropertyItem> PropertyItems { get; init; }
}