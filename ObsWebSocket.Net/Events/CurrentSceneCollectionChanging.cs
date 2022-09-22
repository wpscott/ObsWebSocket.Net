using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     <para>The current scene collection has begun changing.</para>
///     <remarks>
///         Note: We recommend using this event to trigger a pause of all polling requests, as performing any requests
///         during a scene collection change is considered undefined behavior and can cause crashes!
///     </remarks>
/// </summary>
[MessagePackObject]
public struct CurrentSceneCollectionChanging
{
    /// <summary>
    ///     Name of the current scene collection
    /// </summary>
    [JsonPropertyName("sceneCollectionName")]
    [Key("sceneCollectionName")]
    public string SceneCollectionName { get; init; }
}