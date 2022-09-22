using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     <para>Saves a screenshot of a source to the filesystem.</para>
///     <remarks>
///         The <see cref="ImageWidth" /> and <see cref="ImageHeight" /> parameters are treated as "scale to inner",
///         meaning the smallest ratio will be used and the aspect ratio of the original resolution is kept. If
///         <see cref="ImageWidth" /> and <see cref="ImageHeight" /> are not specified, the compressed image will use the
///         full resolution of the source.
///     </remarks>
/// </summary>
[MessagePackObject]
public struct SaveSourceScreenshot
{
    /// <summary>
    ///     Name of the source to take a screenshot of
    /// </summary>
    [JsonPropertyName("sourceName")]
    [Key("sourceName")]
    public string SourceName { get; init; }

    /// <summary>
    ///     Image compression format to use. Use <see cref="ObsWebSocketClient.GetVersion" /> to get compatible image formats
    /// </summary>
    [JsonPropertyName("imageFormat")]
    [Key("imageFormat")]
    public string ImageFormat { get; init; }

    /// <summary>
    ///     Path to save the screenshot file to. E.g. <c>C:\Users\user\Desktop\screenshot.png</c>
    /// </summary>
    [JsonPropertyName("imageFilePath")]
    [Key("imageFilePath")]
    public string ImageFilePath { get; init; }

    /// <summary>
    ///     <para>Width to scale the screenshot to</para>
    ///     <remarks>8 &lt;= value &lt;= 4096</remarks>
    /// </summary>
    [JsonPropertyName("imageWidth")]
    [Key("imageWidth")]
    public uint? ImageWidth { get; init; }

    /// <summary>
    ///     <para>Height to scale the screenshot to</para>
    ///     <remarks>8 &lt;= value &lt;= 4096</remarks>
    /// </summary>
    [JsonPropertyName("imageHeight")]
    [Key("imageHeight")]
    public uint? ImageHeight { get; init; }

    /// <summary>
    ///     Compression quality to use. 0 for high compression, 100 for uncompressed. -1 to use "default" (whatever that
    ///     means, idk)
    /// </summary>
    [JsonPropertyName("imageCompressionQuality")]
    [Key("imageCompressionQuality")]
    public sbyte? ImageCompressionQuality { get; init; }
}

/// <summary>
///     Saves a screenshot of a source to the filesystem.
/// </summary>
[MessagePackObject]
public struct SaveSourceScreenshotResponse
{
    /// <summary>
    ///     Base64-encoded screenshot
    /// </summary>
    [JsonPropertyName("imageData")]
    [Key("imageData")]
    public string ImageData { get; init; }
}