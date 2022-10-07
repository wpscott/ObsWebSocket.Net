using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the current preview scene.</para>
///     <remarks>Only available when studio mode is enabled.</remarks>
/// </summary>
[MessagePackObject]
public class GetCurrentPreviewSceneResponse
{
    /// <summary>
    ///     Current preview scene
    /// </summary>
    [JsonPropertyName("currentPreviewSceneName")]
    [Key("currentPreviewSceneName")]
    public string CurrentPreviewSceneName { get; init; } = null!;
}