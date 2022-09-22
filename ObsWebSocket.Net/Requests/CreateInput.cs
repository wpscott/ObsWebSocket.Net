using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Creates a new input, adding it as a scene item to the specified scene.
/// </summary>
[MessagePackObject]
public struct CreateInput
{
    /// <summary>
    ///     Name of the scene to add the input to as a scene item
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }

    /// <summary>
    ///     Name of the new input to created
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }

    /// <summary>
    ///     The kind of input to be created
    /// </summary>
    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string InputKind { get; init; }

    /// <summary>
    ///     Settings object to initialize the input with
    /// </summary>
    [JsonPropertyName("inputSettings")]
    [Key("inputSettings")]
    public IDictionary<string, object>? InputSettings { get; init; }

    /// <summary>
    ///     Whether to set the created scene item to enabled or disabled
    /// </summary>
    [JsonPropertyName("sceneItemEnabled")]
    [Key("sceneItemEnabled")]
    public bool? SceneItemEnabled { get; init; }
}

/// <summary>
///     Creates a new input, adding it as a scene item to the specified scene.
/// </summary>
[MessagePackObject]
public struct CreateInputResponse
{
    /// <summary>
    ///     ID of the newly created scene item
    /// </summary>
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }
}