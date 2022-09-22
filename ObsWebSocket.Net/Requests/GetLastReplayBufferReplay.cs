using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the filename of the last replay buffer save file.
/// </summary>
[MessagePackObject]
public struct GetLastReplayBufferReplayResponse
{
    /// <summary>
    ///     File path
    /// </summary>
    [JsonPropertyName("savedReplayPath")]
    [Key("savedReplayPath")]
    public string SavedReplayPath { get; init; }
}