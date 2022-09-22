using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The list of scenes has changed.
/// </summary>
[MessagePackObject]
public struct SceneListChanged
{
    /// <summary>
    ///     Updated array of scenes
    /// </summary>
    [JsonPropertyName("scenes")]
    [Key("scenes")]
    public IReadOnlyList<Scene> Scenes { get; init; }
}