using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Basically GetSceneItemList, but for groups.</para>
///     <remarks>
///         Using groups at all in OBS is discouraged, as they are very broken under the hood. Please use nested
///         scenes instead.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct GetGroupSceneItemList
{
    /// <summary>
    ///     Name of the group to get the items of
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }
}

/// <summary>
///     Basically GetSceneItemList, but for groups.
/// </summary>
[MessagePackObject]
public struct GetGroupSceneItemListResponse
{
    /// <summary>
    ///     Array of scene items in the group
    /// </summary>
    [JsonPropertyName("sceneItems")]
    [Key("sceneItems")]
    public IReadOnlyList<SceneItem> SceneItems { get; init; }
}