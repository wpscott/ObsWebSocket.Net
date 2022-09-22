using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all scene collections
/// </summary>
[MessagePackObject]
public struct GetSceneCollectionListResponse
{
    /// <summary>
    ///     The name of the current scene collection
    /// </summary>
    [JsonPropertyName("currentSceneCollectionName")]
    [Key("currentSceneCollectionName")]
    public string CurrentSceneCollectionName { get; init; }

    /// <summary>
    ///     Array of all available scene collections
    /// </summary>
    [JsonPropertyName("sceneCollections")]
    [Key("sceneCollections")]
    public IReadOnlyList<string> SceneCollections { get; init; }
}