namespace ObsWebSocket.Net;

public readonly struct ObsWebSocketClientOptions
{
    public string Address { get; init; }
    public int Port { get; init; }
    public string? Password { get; init; }
    public bool UseMsgPack { get; init; }
    public bool AutoReconnect { get; init; }

    public Uri Host => new($"ws://{Address}:{Port}");
}