using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the scene transition overridden for a scene.
/// </summary>
[MessagePackObject]
public class SetSceneSceneTransitionOverride
{
    /// <summary>
    ///     Name of the scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;

    /// <summary>
    ///     Name of the scene transition to use as override. Specify <see langword="null" /> to remove
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string? TransitionName { get; init; }

    /// <summary>
    ///     <para>Duration to use for any overridden transition. Specify <see langword="null" /> to remove</para>
    ///     <remarks> 50 &lt;= value &lt;= 20000 </remarks>
    /// </summary>
    [JsonPropertyName("transitionDuration")]
    [Key("transitionDuration")]
    public uint? TransitionDuration { get; init; }
}