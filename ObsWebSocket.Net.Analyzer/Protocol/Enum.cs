using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class Enum
{
    [JsonProperty("enumType")] public string EnumType { get; set; }
    [JsonProperty("enumIdentifiers")] public EnumIdentifier[] EnumIdentifiers { get; set; }
}