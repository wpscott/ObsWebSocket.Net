using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Creates a new profile, switching to it in the process
/// </summary>
[MessagePackObject]
public struct CreateProfile
{
    /// <summary>
    ///     Name for the new profile
    /// </summary>
    [JsonPropertyName("profileName")]
    [Key("profileName")]
    public string ProfileName { get; init; }
}