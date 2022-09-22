using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the blend mode of a scene item.</para>
///     <para>See <see cref="ObsBlendingType" /></para>
///     <remarks>Scenes and Groups</remarks>
/// </summary>
[MessagePackObject]
public struct GetSceneItemBlendMode
{
    /// <summary>
    ///     Name of the scene the item is in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }

    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}

/// <summary>
///     Gets the enable state of a scene item.
/// </summary>
[MessagePackObject]
public struct GetSceneItemBlendModeResponse
{
    /// <summary>
    ///     Current blend mode
    /// </summary>
    [JsonPropertyName("sceneItemBlendMode")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("sceneItemBlendMode")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsBlendingType>))]
    public ObsBlendingType SceneItemBlendMode { get; init; }
}