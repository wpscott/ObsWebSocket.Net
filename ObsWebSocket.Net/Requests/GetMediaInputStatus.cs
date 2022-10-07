using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the status of a media input.
/// </summary>
[MessagePackObject]
public class GetMediaInputStatus
{
    /// <summary>
    ///     Name of the media input
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;
}

/// <summary>
///     Gets the status of a media input.
/// </summary>
[MessagePackObject]
public class GetMediaInputStatusResponse
{
    /// <summary>
    ///     State of the media input
    /// </summary>
    [JsonPropertyName("mediaState")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    [Key("mediaState")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsMediaState>))]
    public ObsMediaState MediaState { get; init; }

    /// <summary>
    ///     Total duration of the playing media in milliseconds. <see langword="null" /> if not playing
    /// </summary>
    [JsonPropertyName("mediaDuration")]
    [Key("mediaDuration")]
    public ulong? MediaDuration { get; init; }

    /// <summary>
    ///     Position of the cursor in milliseconds. <see langword="null" /> if not playing
    /// </summary>
    [JsonPropertyName("mediaCursor")]
    [Key("mediaCursor")]
    public ulong? MediaCursor { get; init; }
}