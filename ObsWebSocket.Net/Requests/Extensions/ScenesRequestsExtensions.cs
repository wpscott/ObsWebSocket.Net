using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class ScenesRequestsExtensions
{
    public static Task<GetSceneListResponse> GetSceneList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetSceneListResponse>(RequestType.GetSceneList);
    }

    public static Task<GetGroupListResponse> GetGroupList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetGroupListResponse>(RequestType.GetGroupList);
    }

    public static Task<GetCurrentProgramSceneResponse> GetCurrentProgramScene(this ObsWebSocketClient client)
    {
        return client.Invoke<GetCurrentProgramSceneResponse>(RequestType.GetCurrentProgramScene);
    }

    public static void SetCurrentProgramScene(this ObsWebSocketClient client, string sceneName)
    {
        client.Send(RequestType.SetCurrentProgramScene, new SetCurrentProgramScene { SceneName = sceneName });
    }

    public static Task<GetCurrentPreviewSceneResponse> GetCurrentPreviewScene(this ObsWebSocketClient client)
    {
        return client.Invoke<GetCurrentPreviewSceneResponse>(RequestType.GetCurrentPreviewScene);
    }

    public static void SetCurrentPreviewScene(this ObsWebSocketClient client, string sceneName)
    {
        client.Send(RequestType.SetCurrentPreviewScene, new SetCurrentPreviewScene { SceneName = sceneName });
    }

    public static void CreateScene(this ObsWebSocketClient client, string sceneName)
    {
        client.Send(RequestType.CreateScene, new CreateScene { SceneName = sceneName });
    }

    public static void RemoveScene(this ObsWebSocketClient client, string sceneName)
    {
        client.Send(RequestType.RemoveScene, new RemoveScene { SceneName = sceneName });
    }

    public static void SetSceneName(this ObsWebSocketClient client, string sceneName, string newSceneName)
    {
        client.Send(RequestType.SetSceneName, new SetSceneName { SceneName = sceneName, NewSceneName = newSceneName });
    }

    public static Task<GetSceneSceneTransitionOverrideResponse> GetSceneSceneTransitionOverride(
        this ObsWebSocketClient client, string sceneName)
    {
        return client.Invoke<GetSceneSceneTransitionOverrideResponse>(RequestType.GetSceneSceneTransitionOverride,
            new GetSceneSceneTransitionOverride { SceneName = sceneName });
    }

    public static void SetSceneSceneTransitionOverride(this ObsWebSocketClient client, string sceneName,
        string? transitionName = null, uint? transitionDuration = null)
    {
        client.Send(RequestType.SetSceneSceneTransitionOverride, new SetSceneSceneTransitionOverride
        {
            SceneName = sceneName,
            TransitionName = transitionName,
            TransitionDuration = transitionDuration
        });
    }
}