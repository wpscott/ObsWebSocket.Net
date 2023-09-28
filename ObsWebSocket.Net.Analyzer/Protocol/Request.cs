using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class Request
{
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("requestType")] public string RequestType { get; set; }
    [JsonProperty("complexity")] public long Complexity { get; set; }
    [JsonProperty("rpcVersion")] public long RpcVersion { get; set; }
    [JsonProperty("deprecated")] public bool Deprecated { get; set; }
    [JsonProperty("initialVersion")] public string InitialVersion { get; set; }
    [JsonProperty("category")] public string Category { get; set; }
    [JsonProperty("requestFields")] public RequestField[] RequestFields { get; set; }
    [JsonProperty("responseFields")] public Field[] ResponseFields { get; set; }
}