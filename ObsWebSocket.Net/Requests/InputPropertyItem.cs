using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

[MessagePackObject]
public class InputPropertyItem
{
    [JsonPropertyName("itemName")]
    [Key("itemName")]
    public string ItemName { get; init; } = null!;

    [JsonPropertyName("itemEnabled")]
    [Key("itemEnabled")]
    public bool ItemEnabled { get; init; }

    /// <summary>
    ///     <see cref="long" />, <see cref="double" /> or <see cref="string" />
    /// </summary>
    [JsonPropertyName("itemValue")]
    [Key("itemValue")]
    public object? ItemValue { get; init; }
}