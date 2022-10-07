namespace ObsWebSocket.Net;

public readonly struct ObsWebSocketClientOptions
{
    public const int DefaultAutoReconnectWaitSeconds = 10;

    public string Address { get; init; }
    public int Port { get; init; }
    public string? Password { get; init; }
    public bool UseMsgPack { get; init; }
    public bool AutoReconnect { get; init; }
    public int AutoReconnectWaitSeconds { get; init; }

    public Uri Host => new($"ws://{Address}:{Port}");

    public Task AutoReconnectWait()
    {
        return Task.Delay(AutoReconnectWaitSeconds == 0 ? DefaultAutoReconnectWaitSeconds : AutoReconnectWaitSeconds);
    }
}