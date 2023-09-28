using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class ObsWebSocketProtocol
{
    [JsonProperty("enums")] public Enum[] Enums { get; set; }
    [JsonProperty("requests")] public Request[] Requests { get; set; }
    [JsonProperty("events")] public Event[] Events { get; set; }
}