using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the list of available outputs.
/// </summary>
[MessagePackObject]
public struct GetOutputListResponse
{
    /// <summary>
    ///     Array of outputs
    /// </summary>
    [JsonPropertyName("outputs")]
    [Key("outputs")]
    public IReadOnlyList<Output> Outputs { get; init; }
}