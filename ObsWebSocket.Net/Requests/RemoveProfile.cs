using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Removes a profile. If the current profile is chosen, it will change to a different profile first.
/// </summary>
[MessagePackObject]
public class RemoveProfile
{
    /// <summary>
    ///     Name of the profile to remove
    /// </summary>
    [JsonPropertyName("profileName")]
    [Key("profileName")]
    public string ProfileName { get; init; } = null!;
}