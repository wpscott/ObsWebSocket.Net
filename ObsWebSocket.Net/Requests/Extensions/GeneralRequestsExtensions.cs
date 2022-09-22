using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Requests.Extensions;

public static class GeneralRequestsExtensions
{
    public static Task<GetVersionResponse> GetVersion(this ObsWebSocketClient client)
    {
        return client.Invoke<GetVersionResponse>(RequestType.GetVersion);
    }

    public static Task<GetStatsResponse> GetStats(this ObsWebSocketClient client)
    {
        return client.Invoke<GetStatsResponse>(RequestType.GetStats);
    }

    public static void BroadcastCustomEvent(this ObsWebSocketClient client, IDictionary<string, object> data)
    {
        client.Send(RequestType.BroadcastCustomEvent, new BroadcastCustomEventRequest { EventData = data });
    }

    public static Task<CallVendorRequestResponse> CallVendorRequest(this ObsWebSocketClient client,
        string vendorName, string requestType,
        IDictionary<string, object>? data = null)
    {
        return client.Invoke<CallVendorRequestResponse>(RequestType.CallVendorRequest,
            new CallVendorRequest { VendorName = vendorName, RequestType = requestType, RequestData = data });
    }

    public static Task<GetHotkeyListResponse> GetHotkeyList(this ObsWebSocketClient client)
    {
        return client.Invoke<GetHotkeyListResponse>(RequestType.GetHotkeyList);
    }

    public static void TriggerHotkeyByName(this ObsWebSocketClient client, string hotkeyName)
    {
        client.Send(RequestType.TriggerHotkeyByName, new TriggerHotkeyByName { HotkeyName = hotkeyName });
    }

    public static void TriggerHotkeyByKeySequence(this ObsWebSocketClient client, ObsHotKeys keyId,
        bool? shift = null,
        bool? control = null, bool? alt = null, bool? command = null)
    {
        KeyModifier? modifier = null;
        if (shift != null || control != null || alt != null || command != null)
            modifier = new KeyModifier
            {
                Shift = shift,
                Control = control,
                Alt = alt,
                Command = command
            };

        client.Send(RequestType.TriggerHotkeyByKeySequence, new TriggerHotkeyByKeySequence
        {
            KeyId = keyId,
            KeyModifiers = modifier
        });
    }

    //public static void Sleep(this ObsWebSocketClient client, uint sleepMillis = 0, uint sleepFrames = 0)
    //{
    //    if (sleepMillis is < 0 or > 50000) throw new ArgumentOutOfRangeException(nameof(sleepMillis));
    //    if (sleepFrames is < 0 or > 10000) throw new ArgumentOutOfRangeException(nameof(sleepFrames));

    //    client.Send(RequestType.Sleep, new Sleep
    //    {
    //        SleepFrames = sleepFrames,
    //        SleepMillis = sleepMillis,
    //    });
    //}
}