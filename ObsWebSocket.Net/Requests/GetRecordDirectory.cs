using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the current directory that the record output is set to.
/// </summary>
[MessagePackObject]
public struct GetRecordDirectoryResponse
{
    /// <summary>
    ///     Output directory
    /// </summary>
    [JsonPropertyName("recordDirectory")]
    [Key("recordDirectory")]
    public string RecordDirectory { get; init; }
}