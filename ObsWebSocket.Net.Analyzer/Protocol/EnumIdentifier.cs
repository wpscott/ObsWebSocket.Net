using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class EnumIdentifier
{
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("enumIdentifier")] public string EnumIdentifierEnumIdentifier { get; set; }
    [JsonProperty("rpcVersion")] public long RpcVersion { get; set; }
    [JsonProperty("deprecated")] public bool Deprecated { get; set; }
    [JsonProperty("initialVersion")] public string InitialVersion { get; set; }
    [JsonProperty("enumValue")] public string EnumValue { get; set; }
}