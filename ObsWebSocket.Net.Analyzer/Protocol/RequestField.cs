using Newtonsoft.Json;

namespace ObsWebSocket.Net.Analyzer.Protocol;

public class RequestField : Field
{
    [JsonProperty("valueRestrictions")] public string ValueRestrictions { get; set; }
    [JsonProperty("valueOptional")] public bool ValueOptional { get; set; }

    [JsonProperty("valueOptionalBehavior")]
    public string ValueOptionalBehavior { get; set; }
}