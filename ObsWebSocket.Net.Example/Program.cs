using ObsWebSocket.Net;

using EventWaitHandle ewh = new(false, EventResetMode.ManualReset);

var client = args.Length switch
{
    5 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2], bool.Parse(args[3]), bool.Parse(args[4])),
    4 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2], bool.Parse(args[3])),
    3 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2]),
    2 => new ObsWebSocketClient(args[0], int.Parse(args[1])),
    _ => throw new ArgumentException("Invalid argument numbers")
};

client.OnIdentified += () => { Console.WriteLine("OBS connected"); };

client.OnConnectionFailed += (e) =>
{
    Console.WriteLine(e.Message);
    ewh.Set();
};

client.OnClosed += () =>
{
    Console.WriteLine("OBS disconnected");
    ewh.Set();
};

client.OnIdentified += async () =>
{
    //var version = await client.GetVersion();
    //var results = await client.Invoke(requests: new[]
    //{
    //    new Request { RequestType = RequestType.GetVersion }, new Request { RequestType = RequestType.GetStats }
    //});
    //var settings = await client.GetStreamServiceSettings();

    var scenes = await client.GetSceneList();
    if (scenes == null) return;
    var input = await client.CreateInput(
        scenes.CurrentProgramSceneName,
        "ObsWebSocket.Net.Example",
        "browser_source",
        new Dictionary<string, object>
        {
            { "url", "https://github.com" }
        },
        true);
    //var items = await client.GetSceneItemList(scenes.CurrentProgramSceneName);
    //var result = await client.Invoke(requests: new[]
    //{
    //    new Request
    //    {
    //        RequestType = RequestType.GetInputDefaultSettings,
    //        RequestData = new GetInputDefaultSettings { InputKind = "text_gdiplus_v2" }
    //    },
    //    new Request
    //    {
    //        RequestType = RequestType.GetInputDefaultSettings,
    //        RequestData = new GetInputDefaultSettings { InputKind = "image_source" }
    //    },
    //    new Request
    //    {
    //        RequestType = RequestType.GetInputDefaultSettings,
    //        RequestData = new GetInputDefaultSettings { InputKind = "ffmpeg_source" }
    //    },
    //    new Request
    //    {
    //        RequestType = RequestType.GetInputDefaultSettings,
    //        RequestData = new GetInputDefaultSettings { InputKind = "browser_source" }
    //    },
    //});
    //result = await client.Invoke(requests: items.SceneItems.Select(item => new Request
    //{
    //    RequestType = RequestType.GetInputSettings,
    //    RequestData = new GetInputSettings { InputName = item.SourceName }
    //}).ToArray());
};

client.OnSceneItemSelected += selected =>
{
    Console.WriteLine($"{selected?.SceneItemId} - {selected?.SceneName} selected");
};

client.Connect();

ewh.WaitOne();