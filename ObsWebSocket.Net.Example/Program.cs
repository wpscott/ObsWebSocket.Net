using ObsWebSocket.Net;
using ObsWebSocket.Net.Enums;
using ObsWebSocket.Net.Messages;

using EventWaitHandle ewh = new(false, EventResetMode.ManualReset);

var client = args.Length switch
{
    5 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2], bool.Parse(args[3]), bool.Parse(args[4])),
    4 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2], bool.Parse(args[3])),
    3 => new ObsWebSocketClient(args[0], int.Parse(args[1]), args[2]),
    2 => new ObsWebSocketClient(args[0], int.Parse(args[1])),
    _ => throw new ArgumentException("Invalid argument numbers")
};

client.OnClosed += () => { ewh.Set(); };

client.OnIdentified += async () =>
{
    var version = client.GetVersion();
    var results = await client.Invoke(requests: new[]
    {
        new Request { RequestType = RequestType.GetVersion }, new Request { RequestType = RequestType.GetStats }
    });
};

client.OnSceneItemSelected += selected =>
{
    Console.WriteLine($"{selected.SceneItemId} - {selected.SceneName} selected");
};

client.Connect();

ewh.WaitOne();