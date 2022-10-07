using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the blend mode of a scene item.</para>
///     <remarks>Scenes and Groups</remarks>
/// </summary>
[MessagePackObject]
public class SetSceneItemBlendMode
{
    /// <summary>
    ///     Name of the scene the item is in
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Numeric ID of the scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    /// <summary>
    ///     New blend mode
    /// </summary>
    [JsonPropertyName("sceneItemBlendMode")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("sceneItemBlendMode")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsBlendingType>))]
    public ObsBlendingType SceneItemBlendMode { get; init; }
}