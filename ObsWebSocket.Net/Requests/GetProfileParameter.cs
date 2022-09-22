using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets a parameter from the current profile's configuration.
/// </summary>
[MessagePackObject]
public struct GetProfileParameter
{
    /// <summary>
    ///     Category of the parameter to get
    /// </summary>
    [JsonPropertyName("parameterCategory")]
    [Key("parameterCategory")]
    public string ParameterCategory { get; init; }

    /// <summary>
    ///     Name of the parameter to get
    /// </summary>
    [JsonPropertyName("parameterName")]
    [Key("parameterName")]
    public string ParameterName { get; init; }
}

/// <summary>
///     Gets a parameter from the current profile's configuration.
/// </summary>
[MessagePackObject]
public struct GetProfileParameterResponse
{
    /// <summary>
    ///     Value associated with the parameter. <see langword="null" /> if not set and no default
    /// </summary>
    [JsonPropertyName("parameterValue")]
    [Key("parameterValue")]
    public string? ParameterValue { get; init; }

    /// <summary>
    ///     Default value associated with the parameter. <see langword="null" /> if no default
    /// </summary>
    [JsonPropertyName("defaultParameterValue")]
    [Key("defaultParameterValue")]
    public string? DefaultParameterValue { get; init; }
}