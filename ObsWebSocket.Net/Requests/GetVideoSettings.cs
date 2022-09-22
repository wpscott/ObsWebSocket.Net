using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Gets the current video settings.</para>
///     <remarks>
///         Note: To get the true FPS value, divide the FPS numerator by the FPS denominator.
///         <example>Example: 60000/1001</example>
///     </remarks>
/// </summary>
[MessagePackObject]
public struct GetVideoSettingsResponse
{
    /// <summary>
    ///     Numerator of the fractional FPS value
    /// </summary>
    [JsonPropertyName("fpsNumerator")]
    [Key("fpsNumerator")]
    public uint FpsNumerator { get; init; }

    /// <summary>
    ///     Denominator of the fractional FPS value
    /// </summary>
    [JsonPropertyName("fpsDenominator")]
    [Key("fpsDenominator")]
    public uint FpsDenominator { get; init; }

    /// <summary>
    ///     Width of the base (canvas) resolution in pixels
    /// </summary>
    [JsonPropertyName("baseWidth")]
    [Key("baseWidth")]
    public uint BaseWidth { get; init; }

    /// <summary>
    ///     Height of the base (canvas) resolution in pixels
    /// </summary>
    [JsonPropertyName("baseHeight")]
    [Key("baseHeight")]
    public uint BaseHeight { get; init; }

    /// <summary>
    ///     Width of the output resolution in pixels
    /// </summary>
    [JsonPropertyName("outputWidth")]
    [Key("outputWidth")]
    public uint OutputWidth { get; init; }

    /// <summary>
    ///     Height of the output resolution in pixels
    /// </summary>
    [JsonPropertyName("outputHeight")]
    [Key("outputHeight")]
    public uint OutputHeight { get; init; }
}