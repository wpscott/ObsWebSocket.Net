using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets an array of all groups in OBS.</para>
///     <para>
///         Groups in OBS are actually scenes, but renamed and modified. In obs-websocket, we treat them as scenes where
///         we can.
///     </para>
/// </summary>
[MessagePackObject]
public struct GetGroupListResponse
{
    /// <summary>
    ///     Array of group names
    /// </summary>
    [JsonPropertyName("groups")]
    [Key("groups")]
    public IReadOnlyList<string> Groups { get; init; }
}