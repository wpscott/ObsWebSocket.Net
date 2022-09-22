using ObsWebSocket.Net.Messages.Json;

namespace ObsWebSocket.Net.Enums;

public enum WebSocketCloseCode
{
    /// <summary>
    ///     For internal use only to tell the request handler not to perform any close action.
    /// </summary>
    DontClose,

    /// <summary>
    ///     Unknown reason, should never be used.
    /// </summary>
    UnknownReason = 4000,

    /// <summary>
    ///     The server was unable to decode the incoming websocket message.
    /// </summary>
    MessageDecodeError = 4002,

    /// <summary>
    ///     A data field is required but missing from the payload.
    /// </summary>
    MissingDataField,

    /// <summary>
    ///     A data field's value type is invalid.
    /// </summary>
    InvalidDataFieldType,

    /// <summary>
    ///     A data field's value is invalid.
    /// </summary>
    InvalidDataFieldValue,

    /// <summary>
    ///     The specified <see cref="Message.OpCode" /> was invalid or missing.
    /// </summary>
    UnknownOpCode,

    /// <summary>
    ///     The client sent a websocket message without first sending <see cref="Messages.Identify" /> message.
    /// </summary>
    NotIdentified,

    /// <summary>
    ///     <para>The client sent an <see cref="Messages.Identify" /> message while already identified.</para>
    ///     <remarks>
    ///         Note: Once a client has identified, only <see cref="Messages.Reidentify" /> may be used to
    ///         change session parameters.
    ///     </remarks>
    /// </summary>
    AlreadyIdentified,

    /// <summary>
    ///     The authentication attempt (via <see cref="Messages.Identify" />) failed.
    /// </summary>
    AuthenticationFailed,

    /// <summary>
    ///     The server detected the usage of an old version of the obs-websocket RPC protocol.
    /// </summary>
    UnsupportedRpcVersion,

    /// <summary>
    ///     <para>The websocket session has been invalidated by the obs-websocket server.</para>
    ///     <remarks>
    ///         Note: This is the code used by the <c>Kick</c> button in the UI Session List. If you receive this code,
    ///         you must not automatically reconnect.
    ///     </remarks>
    /// </summary>
    SessionInvalidated,

    /// <summary>
    ///     A requested feature is not supported due to hardware/software limitations.
    /// </summary>
    UnsupportedFeature
}