using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the value of a parameter in the current profile's configuration.
/// </summary>
[MessagePackObject]
public struct SetProfileParameter
{
    /// <summary>
    ///     Category of the parameter to set
    /// </summary>
    [JsonPropertyName("parameterCategory")]
    [Key("parameterCategory")]
    public string ParameterCategory { get; init; }

    /// <summary>
    ///     Name of the parameter to set
    /// </summary>
    [JsonPropertyName("parameterName")]
    [Key("parameterName")]
    public string ParameterName { get; init; }

    /// <summary>
    ///     Value of the parameter to set. Use <see langword="null" /> to delete
    /// </summary>
    [JsonPropertyName("parameterValue")]
    [Key("parameterValue")]
    public string? ParameterValue { get; init; }
}