using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class Event
{
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("eventType")] public string EventType { get; set; }
    [JsonProperty("eventSubscription")] public string EventSubscription { get; set; }
    [JsonProperty("complexity")] public byte Complexity { get; set; }
    [JsonProperty("rpcVersion")] public byte RpcVersion { get; set; }
    [JsonProperty("deprecated")] public bool Deprecated { get; set; }
    [JsonProperty("initialVersion")] public string InitialVersion { get; set; }
    [JsonProperty("category")] public string Category { get; set; }
    [JsonProperty("dataFields")] public Field[] DataFields { get; set; }
}