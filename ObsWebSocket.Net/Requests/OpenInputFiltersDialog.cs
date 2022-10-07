using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Opens the filters dialog of an input.
/// </summary>
[MessagePackObject]
public class OpenInputFiltersDialog
{
    /// <summary>
    ///     Name of the input to open the dialog of
    /// </summary>
    [JsonPropertyName("inputName")]
    [Key("inputName")]
    public string InputName { get; init; } = null!;
}