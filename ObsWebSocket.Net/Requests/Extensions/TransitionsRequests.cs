using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class TransitionsRequests
{
    public static Task<GetTransitionKindListResponse> GetTransitionKindList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetTransitionKindListResponse>(RequestType.GetTransitionKindList);
    }

    public static Task<GetSceneTransitionListResponse> GetSceneTransitionList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetSceneTransitionListResponse>(RequestType.GetSceneTransitionList);
    }

    public static Task<GetCurrentSceneTransitionCursorResponse> GetCurrentSceneTransition(
        this ObsWebSocketClient client)
    {
        return client.Invoke<GetCurrentSceneTransitionCursorResponse>(RequestType.GetCurrentSceneTransition);
    }

    public static void SetCurrentSceneTransition(this ObsWebSocketClient client, string transitionName)
    {
        client.Send(RequestType.SetCurrentSceneTransition,
            new SetCurrentSceneTransition { TransitionName = transitionName });
    }

    public static void SetCurrentSceneTransitionDuration(this ObsWebSocketClient client, uint transitionDuration)
    {
        client.Send(RequestType.SetCurrentSceneTransitionDuration,
            new SetCurrentSceneTransitionDuration { TransitionDuration = transitionDuration });
    }

    public static void SetCurrentSceneTransitionSettings(this ObsWebSocketClient client,
        IDictionary<string, object> transitionSettings, bool? overlay = null)
    {
        client.Send(RequestType.SetCurrentSceneTransitionSettings,
            new SetCurrentSceneTransitionSettings { TransitionSettings = transitionSettings, Overlay = overlay });
    }

    public static Task<GetCurrentSceneTransitionCursorResponse> GetCurrentSceneTransitionCursor(
        this ObsWebSocketClient client)
    {
        return client.Invoke<GetCurrentSceneTransitionCursorResponse>(RequestType.GetCurrentSceneTransitionCursor);
    }

    public static void TriggerStudioModeTransition(this ObsWebSocketClient client)
    {
        client.Send(RequestType.TriggerStudioModeTransition);
    }

    public static void SetTBarPosition(this ObsWebSocketClient client, float position, bool? release = null)
    {
        if (position is < 0 or > 1) throw new ArgumentOutOfRangeException(nameof(position));
        client.Send(RequestType.SetTBarPosition, new SetTBarPosition { Position = position, Release = release });
    }
}