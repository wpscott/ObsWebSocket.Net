using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Removes a scene from OBS.
/// </summary>
[MessagePackObject]
public struct RemoveScene
{
    /// <summary>
    ///     Name of the scene to remove
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }
}