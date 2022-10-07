using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Messages;

[MessagePackObject]
internal class Identified
{
    [JsonPropertyName("negotiatedRpcVersion")]
    [Key("negotiatedRpcVersion")]
    public int NegotiatedRpcVersion { get; init; }
}