using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Creates a new scene in OBS.
/// </summary>
[MessagePackObject]
public struct CreateScene
{
    /// <summary>
    ///     Name for the new scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }
}