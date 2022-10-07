using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the names of all special inputs.
/// </summary>
[MessagePackObject]
public class GetSpecialInputsResponse
{
    /// <summary>
    ///     Name of the Desktop Audio input
    /// </summary>
    [JsonPropertyName("desktop1")]
    [Key("desktop1")]
    public string Desktop1 { get; init; } = null!;

    /// <summary>
    ///     Name of the Desktop Audio 2 input
    /// </summary>
    [JsonPropertyName("desktop2")]
    [Key("desktop2")]
    public string Desktop2 { get; init; } = null!;

    /// <summary>
    ///     Name of the Mic/Auxiliary Audio input
    /// </summary>
    [JsonPropertyName("mic1")]
    [Key("mic1")]
    public string Mic1 { get; init; } = null!;

    /// <summary>
    ///     Name of the Mic/Auxiliary Audio 2 input
    /// </summary>
    [JsonPropertyName("mic2")]
    [Key("mic2")]
    public string Mic2 { get; init; } = null!;

    /// <summary>
    ///     Name of the Mic/Auxiliary Audio 3 input
    /// </summary>
    [JsonPropertyName("mic3")]
    [Key("mic3")]
    public string Mic3 { get; init; } = null!;

    /// <summary>
    ///     Name of the Mic/Auxiliary Audio 4 input
    /// </summary>
    [JsonPropertyName("mic4")]
    [Key("mic4")]
    public string Mic4 { get; init; } = null!;
}