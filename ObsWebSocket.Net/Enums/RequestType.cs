using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RequestType : byte
{
    #region General Requests

    GetVersion,
    GetStats,
    BroadcastCustomEvent,
    CallVendorRequest,
    GetHotkeyList,
    TriggerHotkeyByName,
    TriggerHotkeyByKeySequence,
    Sleep,

    #endregion

    #region Config Requests

    GetPersistentData,
    SetPersistentData,
    GetSceneCollectionList,
    SetCurrentSceneCollection,
    CreateSceneCollection,
    GetProfileList,
    SetCurrentProfile,
    CreateProfile,
    RemoveProfile,
    GetProfileParameter,
    SetProfileParameter,
    GetVideoSettings,
    SetVideoSettings,
    GetStreamServiceSettings,
    SetStreamServiceSettings,
    GetRecordDirectory,

    #endregion

    #region Sources Requests

    GetSourceActive,
    GetSourceScreenshot,
    SaveSourceScreenshot,

    #endregion

    #region Scenes Requests

    GetSceneList,
    GetGroupList,
    GetCurrentProgramScene,
    SetCurrentProgramScene,
    GetCurrentPreviewScene,
    SetCurrentPreviewScene,
    CreateScene,
    RemoveScene,
    SetSceneName,
    GetSceneSceneTransitionOverride,
    SetSceneSceneTransitionOverride,

    #endregion

    #region Inputs Requests

    GetInputList,
    GetInputKindList,
    GetSpecialInputs,
    CreateInput,
    RemoveInput,
    SetInputName,
    GetInputDefaultSettings,
    GetInputSettings,
    SetInputSettings,
    GetInputMute,
    SetInputMute,
    ToggleInputMute,
    GetInputVolume,
    SetInputVolume,
    GetInputAudioBalance,
    SetInputAudioBalance,
    GetInputAudioSyncOffset,
    SetInputAudioSyncOffset,
    GetInputAudioMonitorType,
    SetInputAudioMonitorType,
    GetInputAudioTracks,
    SetInputAudioTracks,
    GetInputPropertiesListPropertyItems,
    PressInputPropertiesButton,

    #endregion

    #region Transitions Requests

    GetTransitionKindList,
    GetSceneTransitionList,
    GetCurrentSceneTransition,
    SetCurrentSceneTransition,
    SetCurrentSceneTransitionDuration,
    SetCurrentSceneTransitionSettings,
    GetCurrentSceneTransitionCursor,
    TriggerStudioModeTransition,
    SetTBarPosition,

    #endregion

    #region Filters Requests

    GetSourceFilterList,
    GetSourceFilterDefaultSettings,
    CreateSourceFilter,
    RemoveSourceFilter,
    SetSourceFilterName,
    GetSourceFilter,
    SetSourceFilterIndex,
    SetSourceFilterSettings,
    SetSourceFilterEnabled,

    #endregion

    #region Scene Items Requests

    GetSceneItemList,
    GetGroupSceneItemList,
    GetSceneItemId,
    CreateSceneItem,
    RemoveSceneItem,
    DuplicateSceneItem,
    GetSceneItemTransform,
    SetSceneItemTransform,
    GetSceneItemEnabled,
    SetSceneItemEnabled,
    GetSceneItemLocked,
    SetSceneItemLocked,
    GetSceneItemIndex,
    SetSceneItemIndex,
    GetSceneItemBlendMode,
    SetSceneItemBlendMode,

    #endregion

    #region Outputs Requests

    GetVirtualCamStatus,
    ToggleVirtualCam,
    StartVirtualCam,
    StopVirtualCam,
    GetReplayBufferStatus,
    ToggleReplayBuffer,
    StartReplayBuffer,
    StopReplayBuffer,
    SaveReplayBuffer,
    GetLastReplayBufferReplay,
    GetOutputList,
    GetOutputStatus,
    ToggleOutput,
    StartOutput,
    StopOutput,
    GetOutputSettings,
    SetOutputSettings,

    #endregion

    #region Stream Requests

    GetStreamStatus,
    ToggleStream,
    StartStream,
    StopStream,
    SendStreamCaption,

    #endregion

    #region Record Requests

    GetRecordStatus,
    ToggleRecord,
    StartRecord,
    StopRecord,
    ToggleRecordPause,
    PauseRecord,
    ResumeRecord,

    #endregion

    #region Media Inputs Requests

    GetMediaInputStatus,
    SetMediaInputCursor,
    OffsetMediaInputCursor,
    TriggerMediaInputAction,

    #endregion

    #region Ui Requests

    GetStudioModeEnabled,
    SetStudioModeEnabled,
    OpenInputPropertiesDialog,
    OpenInputFiltersDialog,
    OpenInputInteractDialog,
    GetMonitorList,
    OpenVideoMixProjector,
    OpenSourceProjector,

    #endregion
}