using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     The scene collection list has changed.
/// </summary>
[MessagePackObject]
public struct SceneCollectionListChanged
{
    /// <summary>
    ///     Updated list of scene collections
    /// </summary>
    [JsonPropertyName("sceneCollections")]
    [Key("sceneCollections")]
    public IReadOnlyList<string> SceneCollection { get; init; }
}