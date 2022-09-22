using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class SourcesRequestsExtensions
{
    public static Task<GetSourceActiveResponse> GetSourceActive(this ObsWebSocketClient client,
        string sourceName)
    {
        return client.Invoke<GetSourceActiveResponse>(RequestType.GetSourceActive,
            new GetSourceActive { SourceName = sourceName });
    }

    public static Task<GetSourceScreenshotResponse> GetSourceScreenshot(this ObsWebSocketClient client,
        string sourceName, string imageFormat, uint? imageWidth = null, uint? imageHeight = null,
        sbyte? imageCompressionQuality = null)
    {
        return client.Invoke<GetSourceScreenshotResponse>(RequestType.GetSourceScreenshot, new GetSourceScreenshot
        {
            SourceName = sourceName,
            ImageFormat = imageFormat,
            ImageWidth = imageWidth,
            ImageHeight = imageHeight,
            ImageCompressionQuality = imageCompressionQuality
        });
    }

    public static Task<SaveSourceScreenshotResponse> SaveSourceScreenshot(this ObsWebSocketClient client,
        string sourceName, string imageFormat, string imageFilePath, uint? imageWidth = null,
        uint? imageHeight = null,
        sbyte? imageCompressionQuality = null)
    {
        return client.Invoke<SaveSourceScreenshotResponse>(RequestType.SaveSourceScreenshot,
            new SaveSourceScreenshot
            {
                SourceName = sourceName,
                ImageFormat = imageFormat,
                ImageFilePath = imageFilePath,
                ImageWidth = imageWidth,
                ImageHeight = imageHeight,
                ImageCompressionQuality = imageCompressionQuality
            });
    }
}