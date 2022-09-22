using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Creates a new scene collection, switching to it in the process.</para>
///     <remarks>Note: This will block until the collection has finished changing.</remarks>
/// </summary>
[MessagePackObject]
public struct CreateSceneCollection
{
    /// <summary>
    ///     Name for the new scene collection
    /// </summary>
    [JsonPropertyName("sceneCollectionName")]
    [Key("sceneCollectionName")]
    public string SceneCollectionName { get; init; }
}