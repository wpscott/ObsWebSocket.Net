using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the scene transition overridden for a scene.
/// </summary>
[MessagePackObject]
public class GetSceneSceneTransitionOverride
{
    /// <summary>
    ///     Name of the scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; } = null!;
}

/// <summary>
///     Gets the scene transition overridden for a scene.
/// </summary>
[MessagePackObject]
public class GetSceneSceneTransitionOverrideResponse
{
    /// <summary>
    ///     Name of the overridden scene transition, else <see langword="null" />
    /// </summary>
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string? TransitionName { get; init; }

    /// <summary>
    ///     Duration of the overridden scene transition, else <see langword="null" />
    /// </summary>
    [JsonPropertyName("transitionDuration")]
    [Key("transitionDuration")]
    public uint? TransitionDuration { get; init; }
}