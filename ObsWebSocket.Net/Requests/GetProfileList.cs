using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all profiles
/// </summary>
[MessagePackObject]
public class GetProfileListResponse
{
    /// <summary>
    ///     The name of the current profile
    /// </summary>
    [JsonPropertyName("currentProfileName")]
    [Key("currentProfileName")]
    public string CurrentProfileName { get; init; } = null!;

    /// <summary>
    ///     Array of all available profiles
    /// </summary>
    [JsonPropertyName("profiles")]
    [Key("profiles")]
    public IReadOnlyList<string> Profiles { get; init; } = null!;
}