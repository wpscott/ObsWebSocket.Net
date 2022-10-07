using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public struct SceneItem
{
    [JsonPropertyName("sceneItemId")]
    [Key("sceneItemId")]
    public ulong SceneItemId { get; init; }

    [JsonPropertyName("sceneItemIndex")]
    [Key("sceneItemIndex")]
    public int SceneItemIndex { get; init; }

    [JsonPropertyName("sceneItemEnabled")]
    [Key("sceneItemEnabled")]
    public bool? SceneItemEnabled { get; init; }

    [JsonPropertyName("sceneItemLocked")]
    [Key("sceneItemLocked")]
    public bool? SceneItemLocked { get; init; }

    [JsonPropertyName("sceneItemTransform")]
    [Key("sceneItemTransform")]
    public SceneItemTransform? SceneItemTransform { get; init; }

    [JsonPropertyName("sceneItemBlendMode")]
    [Key("sceneItemBlendMode")]
    [MessagePackFormatter(typeof(NullableEnumFormatter<ObsBlendingType>))]
    public ObsBlendingType? SceneItemBlendMode { get; init; }

    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string? SourceName { get; init; }

    [JsonPropertyName("sourceType")]
    [Key("sourceType")]
    [MessagePackFormatter(typeof(NullableEnumFormatter<ObsSourceType>))]
    public ObsSourceType? SourceType { get; init; }

    [JsonPropertyName("inputKind")]
    [Key("inputKind")]
    public string? InputKind { get; init; }

    [JsonPropertyName("isGroup")]
    [Key("isGroup")]
    public bool? IsGroup { get; init; }
}

[MessagePackObject]
public struct SceneItemTransform
{
    [JsonPropertyName("sourceWidth")]
    [Key("sourceWidth")]
    public float SourceWidth { get; init; }

    [JsonPropertyName("sourceHeight")]
    [Key("sourceHeight")]
    public float SourceHeight { get; init; }

    [JsonPropertyName("positionX")]
    [Key("positionX")]
    public float PositionX { get; init; }

    [JsonPropertyName("positionY")]
    [Key("positionY")]
    public float PositionY { get; init; }

    [JsonPropertyName("rotation")]
    [Key("rotation")]
    public float Rotation { get; init; }

    [JsonPropertyName("scaleX")]
    [Key("scaleX")]
    public float ScaleX { get; init; }

    [JsonPropertyName("scaleY")]
    [Key("scaleY")]
    public float ScaleY { get; init; }

    [JsonPropertyName("width")]
    [Key("width")]
    public float Width { get; init; }

    [JsonPropertyName("height")]
    [Key("height")]
    public float Height { get; init; }

    [JsonPropertyName("alignment")]
    [Key("alignment")]
    public uint Alignment { get; init; }

    [JsonPropertyName("boundsType")]
    [Key("boundsType")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsBoundsType>))]
    public ObsBoundsType BoundsType { get; init; }

    [JsonPropertyName("boundsAlignment")]
    [Key("boundsAlignment")]
    public uint BoundsAlignment { get; init; }

    [JsonPropertyName("boundsWidth")]
    [Key("boundsWidth")]
    public float BoundsWidth { get; init; }

    [JsonPropertyName("boundsHeight")]
    [Key("boundsHeight")]
    public float BoundsHeight { get; init; }

    [JsonPropertyName("cropLeft")]
    [Key("cropLeft")]
    public int CropLeft { get; init; }

    [JsonPropertyName("cropRight")]
    [Key("cropRight")]
    public int CropRight { get; init; }

    [JsonPropertyName("cropTop")]
    [Key("cropTop")]
    public int CropTop { get; init; }

    [JsonPropertyName("cropBottom")]
    [Key("cropBottom")]
    public int CropBottom { get; init; }
}