﻿using System.Text.Json;
using System.Text.Json.Serialization;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages.Json;

/// <summary>
///     The following message types are the low-level message types which may be sent to and from obs-websocket.
/// </summary>
public class Message
{
    /// <summary>
    ///     <see cref="OpCode" /> is a <see cref="WebSocketOpCode" />.
    /// </summary>
    [JsonPropertyName("op")]
    public WebSocketOpCode OpCode { get; init; }

    /// <summary>
    ///     <see cref="Data" /> is an object of the data fields associated with the operation.
    /// </summary>
    [JsonPropertyName("d")]
    public JsonDocument Data { get; init; } = null!;
}