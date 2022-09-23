using System.Text.Json.Serialization;

namespace ObsWebSocket.Net.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EventType : byte
{
    #region General Events

    ExitStarted,
    VendorEvent,

    #endregion

    #region Config Events

    CurrentSceneCollectionChanging,
    CurrentSceneCollectionChanged,
    SceneCollectionListChanged,
    CurrentProfileChanging,
    CurrentProfileChanged,
    ProfileListChanged,

    #endregion

    #region Scenes Events

    SceneCreated,
    SceneRemoved,
    SceneNameChanged,
    CurrentProgramSceneChanged,
    CurrentPreviewSceneChanged,
    SceneListChanged,

    #endregion

    #region Inputs Events

    InputCreated,
    InputRemoved,
    InputNameChanged,
    InputActiveStateChanged,
    InputShowStateChanged,
    InputMuteStateChanged,
    InputVolumeChanged,
    InputAudioBalanceChanged,
    InputAudioSyncOffsetChanged,
    InputAudioTracksChanged,
    InputAudioMonitorTypeChanged,
    InputVolumeMeters,

    #endregion

    #region Transitions Events

    CurrentSceneTransitionChanged,
    CurrentSceneTransitionDurationChanged,
    SceneTransitionStarted,
    SceneTransitionEnded,
    SceneTransitionVideoEnded,

    #endregion

    #region Filters Events

    SourceFilterListReindexed,
    SourceFilterCreated,
    SourceFilterRemoved,
    SourceFilterNameChanged,
    SourceFilterEnableStateChanged,

    #endregion

    #region Scene Items Events

    SceneItemCreated,
    SceneItemRemoved,
    SceneItemListReindexed,
    SceneItemEnableStateChanged,
    SceneItemLockStateChanged,
    SceneItemSelected,
    SceneItemTransformChanged,

    #endregion

    #region Outputs Events

    StreamStateChanged,
    RecordStateChanged,
    ReplayBufferStateChanged,
    VirtualcamStateChanged,
    ReplayBufferSaved,

    #endregion

    #region Media Inputs Events

    MediaInputPlaybackStarted,
    MediaInputPlaybackEnded,
    MediaInputActionTriggered,

    #endregion

    #region Ui Events

    StudioModeStateChanged,

    #endregion
}