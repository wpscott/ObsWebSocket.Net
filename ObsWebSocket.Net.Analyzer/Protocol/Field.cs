using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class Field
{
    [JsonProperty("valueName")] public string ValueName { get; set; }
    [JsonProperty("valueType")] public string ValueType { get; set; }
    [JsonProperty("valueDescription")] public string ValueDescription { get; set; }
}