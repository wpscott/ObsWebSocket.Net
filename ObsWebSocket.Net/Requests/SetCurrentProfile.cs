using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Switches to a profile.
/// </summary>
[MessagePackObject]
public struct SetCurrentProfile
{
    /// <summary>
    ///     Name of the profile to switch to
    /// </summary>
    [JsonPropertyName("profileName")]
    [Key("profileName")]
    public string ProfileName { get; init; }
}