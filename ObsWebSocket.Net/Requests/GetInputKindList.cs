using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets an array of all available input kinds in OBS.
/// </summary>
[MessagePackObject]
public class GetInputKindList
{
    /// <summary>
    ///     <see langword="true" /> == Return all kinds as unversioned, <see langword="false" /> == Return with version
    ///     suffixes (if available)
    /// </summary>
    [JsonPropertyName("unversioned")]
    [Key("unversioned")]
    public bool? Unversioned { get; init; } = null!;
}

/// <summary>
///     Gets an array of all available input kinds in OBS.
/// </summary>
[MessagePackObject]
public class GetInputKindListResponse
{
    /// <summary>
    ///     Array of input kinds
    /// </summary>
    [JsonPropertyName("inputKinds")]
    [Key("inputKinds")]
    public IReadOnlyList<string> InputKinds { get; init; } = null!;
}