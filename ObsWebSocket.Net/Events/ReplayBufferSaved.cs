using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The replay buffer has been saved.
/// </summary>
[MessagePackObject]
public struct ReplayBufferSaved
{
    /// <summary>
    ///     Path of the saved replay file
    /// </summary>
    [JsonPropertyName("savedReplayPath")]
    [Key("savedReplayPath")]
    public string SavedReplayPath { get; init; }
}