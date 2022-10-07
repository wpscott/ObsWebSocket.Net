using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The current profile has begun changing.
/// </summary>
[MessagePackObject]
public class CurrentProfileChanging
{
    /// <summary>
    ///     Name of the current profile
    /// </summary>
    [JsonPropertyName("profileName")]
    [Key("profileName")]
    public string ProfileName { get; init; } = null!;
}