using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class FiltersRequestsExtensions
{
    public static Task<GetSourceFilterListResponse> GetSourceFilterList(this ObsWebSocketClient client,
        string sourceName)
    {
        return client.Invoke<GetSourceFilterListResponse>(RequestType.GetSourceFilterList,
            new GetSourceFilterList { SourceName = sourceName });
    }

    public static Task<GetSourceFilterDefaultSettingsResponse> GetSourceFilterDefaultSettings(
        this ObsWebSocketClient client, string filterKind)
    {
        return client.Invoke<GetSourceFilterDefaultSettingsResponse>(RequestType.GetSourceFilterDefaultSettings,
            new GetSourceFilterDefaultSettings { FilterKind = filterKind });
    }

    public static void CreateSourceFilter(this ObsWebSocketClient client, string sourceName, string filterName,
        string filterKind, IDictionary<string, object>? filterSettings = null)
    {
        client.Send(RequestType.CreateSourceFilter, new CreateSourceFilter
        {
            SourceName = sourceName,
            FilterName = filterName,
            FilterKind = filterKind,
            FilterSettings = filterSettings
        });
    }

    public static void RemoveSourceFilter(this ObsWebSocketClient client, string sourceName, string filterName)
    {
        client.Send(RequestType.RemoveSourceFilter,
            new RemoveSourceFilter { SourceName = sourceName, FilterName = filterName });
    }

    public static void SetSourceFilterName(this ObsWebSocketClient client, string sourceName, string filterName,
        string newFilterName)
    {
        client.Send(RequestType.SetSourceFilterName,
            new SetSourceFilterName
                { SourceName = sourceName, FilterName = filterName, NewFilterName = newFilterName });
    }

    public static Task<GetSourceFilterResponse> GetSourceFilter(this ObsWebSocketClient client, string sourceName,
        string filterName)
    {
        return client.Invoke<GetSourceFilterResponse>(RequestType.GetSourceFilter,
            new GetSourceFilter { SourceName = sourceName, FilterName = filterName });
    }

    public static void SetSourceFilterIndex(this ObsWebSocketClient client, string sourceName, string filterName,
        uint filterIndex)
    {
        client.Send(RequestType.SetSourceFilterIndex,
            new SetSourceFilterIndex { SourceName = sourceName, FilterName = filterName, FilterIndex = filterIndex });
    }

    public static void SetSourceFilterSettings(this ObsWebSocketClient client, string sourceName, string filterName,
        IDictionary<string, object> filterSettings, bool? overlay = null)
    {
        client.Send(RequestType.SetSourceFilterSettings,
            new SetSourceFilterSettings
            {
                SourceName = sourceName, FilterName = filterName, FilterSettings = filterSettings, Overlay = overlay
            });
    }

    public static void SetSourceFilterEnabled(this ObsWebSocketClient client, string sourceName, string filterName,
        bool filterEnabled)
    {
        client.Send(RequestType.SetSourceFilterEnabled,
            new SetSourceFilterEnabled
                { SourceName = sourceName, FilterName = filterName, FilterEnabled = filterEnabled });
    }
}