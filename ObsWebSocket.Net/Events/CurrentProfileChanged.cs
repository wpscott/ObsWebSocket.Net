using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current profile has changed.
/// </summary>
[MessagePackObject]
public struct CurrentProfileChanged
{
    /// <summary>
    ///     Name of the current profile
    /// </summary>
    [JsonPropertyName("profileName")]
    [Key("profileName")]
    public string ProfileName { get; init; }
}