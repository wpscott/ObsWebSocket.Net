using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The profile list has changed.
/// </summary>
[MessagePackObject]
public class ProfileListChanged
{
    /// <summary>
    ///     Updated list of profiles
    /// </summary>
    [JsonPropertyName("profiles")]
    [Key("profiles")]
    public IReadOnlyList<string> Profiles { get; init; } = null!;
}