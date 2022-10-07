using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Input
{
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;

    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; } = null!;

    [JsonPropertyName("unversionedInputKind")]
    [Key("unversionedInputKind")]
    public string UnversionedInputKind { get; init; } = null!;
}