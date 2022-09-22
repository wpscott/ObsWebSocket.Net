﻿using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Events;

/// <summary>
///     A scene has been removed.
/// </summary>
[MessagePackObject]
public struct SceneRemoved
{
    /// <summary>
    ///     Name of the new scene
    /// </summary>
    [JsonPropertyName("sceneName")]
    [Key("sceneName")]
    public string SceneName { get; init; }

    /// <summary>
    ///     Whether the new scene is a group
    /// </summary>
    [JsonPropertyName("isGroup")]
    [Key("isGroup")]
    public bool IsGroup { get; init; }
}