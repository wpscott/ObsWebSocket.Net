using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public struct Input
{
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; }

    [JsonPropertyName("unversionedInputKind")]
    [Key("unversionedInputKind")]
    public string UnversionedInputKind { get; init; }
}