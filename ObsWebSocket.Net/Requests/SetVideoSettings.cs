using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Sets the current video settings.</para>
///     <remarks>
///         Note: Fields must be specified in pairs. For example, you cannot set only
///         <see cref="BaseWidth" /> without needing to specify <see cref="BaseHeight" />.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct SetVideoSettings
{
    /// <summary>
    ///     <para>Numerator of the fractional FPS value</para>
    ///     <remarks>value &gt;= 1</remarks>
    /// </summary>
    [JsonPropertyName("fpsNumerator")]
    [Key("fpsNumerator")]
    public uint? FpsNumerator { get; init; }

    /// <summary>
    ///     <para>Denominator of the fractional FPS value</para>
    ///     <remarks>value &gt;= 1</remarks>
    /// </summary>
    [JsonPropertyName("fpsDenominator")]
    [Key("fpsDenominator")]
    public uint? FpsDenominator { get; init; }

    /// <summary>
    ///     <para>Width of the base (canvas) resolution in pixels</para>
    ///     <remarks>1 &lt;= value &lt;= 4096 </remarks>
    /// </summary>
    [JsonPropertyName("baseWidth")]
    [Key("baseWidth")]
    [MemberNotNullWhen(true, nameof(BaseHeight))]
    public uint? BaseWidth { get; init; }

    /// <summary>
    ///     <para>Height of the base (canvas) resolution in pixels</para>
    ///     <remarks>1 &lt;= value &lt;= 4096 </remarks>
    /// </summary>
    [JsonPropertyName("baseHeight")]
    [Key("baseHeight")]
    [MemberNotNullWhen(true, nameof(BaseWidth))]
    public uint? BaseHeight { get; init; }

    /// <summary>
    ///     <para>Width of the output resolution in pixels</para>
    ///     <remarks>1 &lt;= value &lt;= 4096 </remarks>
    /// </summary>
    [JsonPropertyName("outputWidth")]
    [Key("outputWidth")]
    public uint? OutputWidth { get; init; }

    /// <summary>
    ///     <para>Height of the output resolution in pixels</para>
    ///     <remarks>1 &lt;= value &lt;= 4096 </remarks>
    /// </summary>
    [JsonPropertyName("outputHeight")]
    [Key("outputHeight")]
    public uint? OutputHeight { get; init; }
}