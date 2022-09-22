using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the position of the TBar.</para>
///     <remarks>Very important note: This will be deprecated and replaced in a future version of obs-websocket.</remarks>
/// </summary>
[MessagePackObject]
public struct SetTBarPosition
{
    /// <summary>
    ///     <para>New position</para>
    ///     <remarks>0.0 &lt;= value &lt;= 1.0</remarks>
    /// </summary>
    [JsonPropertyName("position")]
    [Key("position")]
    public float Position { get; init; }

    /// <summary>
    ///     Whether to release the TBar. Only set <see langword="false" /> if you know that you will be sending another
    ///     position update
    /// </summary>
    [JsonPropertyName("release")]
    [Key("release")]
    public bool? Release { get; init; }
}