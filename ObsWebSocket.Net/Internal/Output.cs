using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Output
{
    [JsonPropertyName("outputName")]
    [Key("outputName")]
    public string OutputName { get; init; } = null!;

    [JsonPropertyName("outputKind")]
    [Key("outputKind")]
    public string OutputKind { get; init; } = null!;

    [JsonPropertyName("outputWidth")]
    [Key("outputWidth")]
    public uint OutputWidth { get; init; }

    [JsonPropertyName("outputHeight")]
    [Key("outputHeight")]
    public uint OutputHeight { get; init; }

    [JsonPropertyName("outputActive")]
    [Key("outputActive")]
    public bool OutputActive { get; init; }

    [JsonPropertyName("outputFlags")]
    [Key("outputFlags")]
    [MessagePackFormatter(typeof(OutputFlagsFormatter))]
    public IReadOnlyDictionary<ObsOutputFlags, bool> OutputFlags { get; init; } = null!;
}