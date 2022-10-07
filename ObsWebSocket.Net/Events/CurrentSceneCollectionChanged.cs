using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     <para>The current scene collection has changed.</para>
///     <remarks>
///         Note: If polling has been paused during
///         <see cref="CurrentSceneCollectionChanging" />, this is the que to restart
///         polling.
///     </remarks>
/// </summary>
[MessagePackObject]
public class CurrentSceneCollectionChanged
{
    /// <summary>
    ///     Name of the current scene collection
    /// </summary>
    [JsonPropertyName("sceneCollectionName")]
    [Key("sceneCollectionName")]
    public string SceneCollectionName { get; init; } = null!;
}