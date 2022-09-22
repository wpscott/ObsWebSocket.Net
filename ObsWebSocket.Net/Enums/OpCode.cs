namespace ObsWebSocket.Net.Enums;

public enum OpCode : byte
{
    /// <summary>
    ///     The initial message sent by obs-websocket to newly connected clients.
    /// </summary>
    Hello,

    /// <summary>
    ///     The message sent by a newly connected client to obs-websocket in response to a
    ///     <see cref="Messages.Hello" />.
    /// </summary>
    Identify,

    /// <summary>
    ///     The response sent by obs-websocket to a client after it has successfully identified with obs-websocket.
    /// </summary>
    Identified,

    /// <summary>
    ///     The message sent by an already-identified client to update identification parameters.
    /// </summary>
    Reidentify,

    /// <summary>
    ///     The message sent by obs-websocket containing an event payload.
    /// </summary>
    Event = 5,

    /// <summary>
    ///     The message sent by a client to obs-websocket to perform a request.
    /// </summary>
    Request,

    /// <summary>
    ///     The message sent by obs-websocket in response to a particular request from a client.
    /// </summary>
    RequestResponse,

    /// <summary>
    ///     The message sent by a client to obs-websocket to perform a batch of requests.
    /// </summary>
    RequestBatch,

    /// <summary>
    ///     The message sent by obs-websocket in response to a particular batch of requests from a client.
    /// </summary>
    RequestBatchResponse
}