using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;
using ObsWebSocket.Net.Internal;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class SceneItemsRequestsExtensions
{
    public static Task<GetSceneItemListResponse> GetSceneItemList(this ObsWebSocketClient client, string sceneName)
    {
        return client.Invoke<GetSceneItemListResponse>(RequestType.GetSceneItemList,
            new GetSceneItemList { SceneName = sceneName });
    }

    public static Task<GetGroupSceneItemListResponse> GetGroupSceneItemList(this ObsWebSocketClient client,
        string sceneName)
    {
        return client.Invoke<GetGroupSceneItemListResponse>(RequestType.GetGroupSceneItemList,
            new GetGroupSceneItemList { SceneName = sceneName });
    }

    public static Task<GetSceneItemIdResponse> GetSceneItemId(this ObsWebSocketClient client, string sceneName,
        string sourceName, int? searchOffset = null)
    {
        return client.Invoke<GetSceneItemIdResponse>(RequestType.GetSceneItemId, new GetSceneItemId
        {
            SceneName = sceneName,
            SourceName = sourceName,
            SearchOffset = searchOffset
        });
    }

    public static Task<CreateSceneItemResponse> CreateSceneItem(this ObsWebSocketClient client, string sceneName,
        string sourceName, bool? sceneItemEnabled = null)
    {
        return client.Invoke<CreateSceneItemResponse>(RequestType.CreateSceneItem,
            new CreateSceneItem
                { SceneName = sceneName, SourceName = sourceName, SceneItemEnabled = sceneItemEnabled });
    }

    public static void RemoveSceneItem(this ObsWebSocketClient client, string sceneName, ulong sceneItemId)
    {
        client.Send(RequestType.RemoveSceneItem,
            new RemoveSceneItem { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static Task<DuplicateSceneItemResponse> DuplicateSceneItem(this ObsWebSocketClient client, string sceneName,
        ulong sceneItemId, string? destinationSceneName = null)
    {
        return client.Invoke<DuplicateSceneItemResponse>(RequestType.DuplicateSceneItem,
            new DuplicateSceneItem
                { SceneName = sceneName, SceneItemId = sceneItemId, DestinationSceneName = destinationSceneName });
    }

    public static Task<GetSceneItemTransformResponse> GetSceneItemTransform(this ObsWebSocketClient client,
        string sceneName, ulong sceneItemId)
    {
        return client.Invoke<GetSceneItemTransformResponse>(RequestType.GetSceneItemTransform,
            new GetSceneItemTransform { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static void SetSceneItemTransform(this ObsWebSocketClient client, string sceneName, ulong sceneItemId,
        SceneItemTransform sceneItemTransform)
    {
        client.Send(RequestType.SetSceneItemTransform,
            new SetSceneItemTransform
                { SceneName = sceneName, SceneItemId = sceneItemId, SceneItemTransform = sceneItemTransform });
    }

    public static Task<GetSceneItemEnabledResponse> GetSceneItemEnabled(this ObsWebSocketClient client,
        string sceneName, ulong sceneItemId)
    {
        return client.Invoke<GetSceneItemEnabledResponse>(RequestType.GetSceneItemEnabled,
            new GetSceneItemEnabled { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static void SetSceneItemEnabled(this ObsWebSocketClient client, string sceneName, ulong sceneItemId,
        bool sceneItemEnabled)
    {
        client.Send(RequestType.SetSceneItemEnabled,
            new SetSceneItemEnabled
                { SceneName = sceneName, SceneItemId = sceneItemId, SceneItemEnabled = sceneItemEnabled });
    }

    public static Task<GetSceneItemLockedResponse> GetSceneItemLocked(this ObsWebSocketClient client, string sceneName,
        ulong sceneItemId)
    {
        return client.Invoke<GetSceneItemLockedResponse>(RequestType.GetSceneItemLocked,
            new GetSceneItemLocked { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static void SetSceneItemLocked(this ObsWebSocketClient client, string sceneName, ulong sceneItemId,
        bool sceneItemLocked)
    {
        client.Send(RequestType.SetSceneItemLocked,
            new SetSceneItemLocked
                { SceneName = sceneName, SceneItemId = sceneItemId, SceneItemLocked = sceneItemLocked });
    }

    public static Task<GetSceneItemIndexResponse> GetSceneItemIndex(this ObsWebSocketClient client, string sceneName,
        ulong sceneItemId)
    {
        return client.Invoke<GetSceneItemIndexResponse>(RequestType.GetSceneItemIndex,
            new GetSceneItemIndex { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static void SetSceneItemIndex(this ObsWebSocketClient client, string sceneName, ulong sceneItemId,
        uint sceneItemIndex)
    {
        client.Send(RequestType.SetSceneItemIndex,
            new SetSceneItemIndex
                { SceneName = sceneName, SceneItemId = sceneItemId, SceneItemIndex = sceneItemIndex });
    }

    public static Task<GetSceneItemBlendModeResponse> GetSceneItemBlendMode(this ObsWebSocketClient client,
        string sceneName, ulong sceneItemId)
    {
        return client.Invoke<GetSceneItemBlendModeResponse>(RequestType.GetSceneItemBlendMode,
            new GetSceneItemBlendMode { SceneName = sceneName, SceneItemId = sceneItemId });
    }

    public static void SetSceneItemBlendMode(this ObsWebSocketClient client, string sceneName, ulong sceneItemId,
        ObsBlendingType sceneItemBLendMode)
    {
        client.Send(RequestType.SetSceneItemBlendMode,
            new SetSceneItemBlendMode
                { SceneName = sceneName, SceneItemId = sceneItemId, SceneItemBlendMode = sceneItemBLendMode });
    }
}