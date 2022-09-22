using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the current preview scene.</para>
///     <remarks>Only available when studio mode is enabled.</remarks>
/// </summary>
[MessagePackObject]
public struct SetCurrentPreviewScene
{
    /// <summary>
    ///     Scene to set as the current preview scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }
}