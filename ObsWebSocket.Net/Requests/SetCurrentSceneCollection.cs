using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Switches to a scene collection.</para>
///     <remarks>Note: This will block until the collection has finished changing.</remarks>
/// </summary>
[MessagePackObject]
public class SetCurrentSceneCollection
{
    /// <summary>
    ///     Name of the scene collection to switch to
    /// </summary>
    [JsonPropertyName("sceneCollectionName")]
    [Key("sceneCollectionName")]
    public string SceneCollectionName { get; init; } = null!;
}