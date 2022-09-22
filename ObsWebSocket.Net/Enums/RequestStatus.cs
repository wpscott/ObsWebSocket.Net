namespace ObsWebSocket.Net.Enums;

public enum RequestStatus
{
    /// <summary>
    ///     Unknown status, should never be used.
    /// </summary>
    Unknown,

    /// <summary>
    ///     For internal use to signify a successful field check.
    /// </summary>
    NoError = 10,

    /// <summary>
    ///     The request has succeeded.
    /// </summary>
    Success = 100,

    /// <summary>
    ///     The requestType field is missing from the request data.
    /// </summary>
    MissingRequestType = 203,

    /// <summary>
    ///     The request type is invalid or does not exist.
    /// </summary>
    UnknownRequestType,

    /// <summary>
    ///     <para>Generic error code.</para>
    ///     <remarks>Note: A comment is required to be provided by obs-websocket.</remarks>
    /// </summary>
    GenericError,

    /// <summary>
    ///     The request batch execution type is not supported.
    /// </summary>
    UnsupportedRequestBatchExecutionType,

    /// <summary>
    ///     A required request field is missing.
    /// </summary>
    MissingRequestField = 300,

    /// <summary>
    ///     The request does not have a valid requestData object.
    /// </summary>
    MissingRequestData,

    /// <summary>
    ///     <para>Generic invalid request field message.</para>
    ///     <remarks>Note: A comment is required to be provided by obs-websocket.</remarks>
    /// </summary>
    InvalidRequestField = 400,

    /// <summary>
    ///     A request field has the wrong data type.
    /// </summary>
    InvalidRequestFieldType,

    /// <summary>
    ///     A request field (number) is outside of the allowed range.
    /// </summary>
    RequestFieldOutOfRange,

    /// <summary>
    ///     A request field (string or array) is empty and cannot be.
    /// </summary>
    RequestFieldEmpty,

    /// <summary>
    ///     There are too many request fields (eg. a request takes two optionals, where only one is allowed at a time).
    /// </summary>
    TooManyRequestFields,

    /// <summary>
    ///     An output is running and cannot be in order to perform the request.
    /// </summary>
    OutputRunning = 500,

    /// <summary>
    ///     An output is not running and should be.
    /// </summary>
    OutputNotRunning,

    /// <summary>
    ///     An output is paused and should not be.
    /// </summary>
    OutputPaused,

    /// <summary>
    ///     An output is not paused and should be.
    /// </summary>
    OutputNotPaused,

    /// <summary>
    ///     An output is disabled and should not be.
    /// </summary>
    OutputDisabled,

    /// <summary>
    ///     Studio mode is active and cannot be.
    /// </summary>
    StudioModeActive,

    /// <summary>
    ///     Studio mode is not active and should be.
    /// </summary>
    StudioModeNotActive,

    /// <summary>
    ///     <para>The resource was not found.</para>
    ///     <remarks>Note: Resources are any kind of object in obs-websocket, like inputs, profiles, outputs, etc.</remarks>
    /// </summary>
    ResourceNotFound = 600,

    /// <summary>
    ///     The resource already exists.
    /// </summary>
    ResourceAlreadyExists,

    /// <summary>
    ///     The type of resource found is invalid.
    /// </summary>
    InvalidResourceType,

    /// <summary>
    ///     There are not enough instances of the resource in order to perform the request.
    /// </summary>
    NotEnoughResources,

    /// <summary>
    ///     The state of the resource is invalid. For example, if the resource is blocked from being accessed.
    /// </summary>
    InvalidResourceState,

    /// <summary>
    ///     The specified input (obs_source_t-OBS_SOURCE_TYPE_INPUT) had the wrong kind.
    /// </summary>
    InvalidInputKind,

    /// <summary>
    ///     <para>The resource does not support being configured.</para>
    ///     <remarks>This is particularly relevant to transitions, where they do not always have changeable settings.</remarks>
    /// </summary>
    ResourceNotConfigurable,

    /// <summary>
    ///     The specified filter (obs_source_t-OBS_SOURCE_TYPE_FILTER) had the wrong kind.
    /// </summary>
    InvalidFilterKind,

    /// <summary>
    ///     Creating the resource failed.
    /// </summary>
    ResourceCreationFailed = 700,

    /// <summary>
    ///     Performing an action on the resource failed.
    /// </summary>
    ResourceActionFailed,

    /// <summary>
    ///     Processing the request failed unexpectedly.
    /// </summary>
    RequestProcessingFailed,

    /// <summary>
    ///     The combination of request fields cannot be used to perform an action.
    /// </summary>
    CannotAct
}