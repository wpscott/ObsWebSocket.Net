using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Removes an existing input.</para>
///     <remarks>Note: Will immediately remove all associated scene items.</remarks>
/// </summary>
[MessagePackObject]
public struct RemoveInput
{
    /// <summary>
    ///     Name of the input to remove
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; }
}