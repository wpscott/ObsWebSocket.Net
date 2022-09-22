using ObsWebSocket.Net.Events;

namespace ObsWebSocket.Net;

#region Obs WebSocket Event delegates

public delegate void ExitStartedHandler();

public delegate void VendorEventHandler(VendorEvent e);

public delegate void CurrentSceneCollectionChangingHandler(CurrentSceneCollectionChanging e);

public delegate void CurrentSceneCollectionChangedHandler(CurrentSceneCollectionChanged e);

public delegate void SceneCollectionListChangedHandler(SceneCollectionListChanged e);

public delegate void CurrentProfileChangingHandler(CurrentProfileChanging e);

public delegate void CurrentProfileChangedHandler(CurrentProfileChanged e);

public delegate void ProfileListChangedHandler(ProfileListChanged e);

public delegate void SceneCreatedHandler(SceneCreated e);

public delegate void SceneRemovedHandler(SceneRemoved e);

public delegate void SceneNameChangedHandler(SceneNameChanged e);

public delegate void CurrentProgramSceneChangedHandler(CurrentProgramSceneChanged e);

public delegate void CurrentPreviewSceneChangedHandler(CurrentPreviewSceneChanged e);

public delegate void SceneListChangedHandler(SceneListChanged e);

public delegate void InputCreatedHandler(InputCreated e);

public delegate void InputRemovedHandler(InputRemoved e);

public delegate void InputNameChangedHandler(InputNameChanged e);

public delegate void InputActiveStateChangedHandler(InputActiveStateChanged e);

public delegate void InputShowStateChangedHandler(InputShowStateChanged e);

public delegate void InputMuteStateChangedHandler(InputMuteStateChanged e);

public delegate void InputVolumeChangedHandler(InputVolumeChanged e);

public delegate void InputAudioBalanceChangedHandler(InputAudioBalanceChanged e);

public delegate void InputAudioSyncOffsetChangedHandler(InputAudioSyncOffsetChanged e);

public delegate void InputAudioTracksChangedHandler(InputAudioTracksChanged e);

public delegate void InputAudioMonitorTypeChangedHandler(InputAudioMonitorTypeChanged e);

public delegate void InputVolumeMetersHandler(InputVolumeMeters e);

public delegate void CurrentSceneTransitionChangedHandler(CurrentSceneTransitionChanged e);

public delegate void CurrentSceneTransitionDurationChangedHandler(CurrentSceneTransitionDurationChanged e);

public delegate void SceneTransitionStartedHandler(SceneTransitionStarted e);

public delegate void SceneTransitionEndedHandler(SceneTransitionEnded e);

public delegate void SceneTransitionVideoEndedHandler(SceneTransitionVideoEnded e);

public delegate void SourceFilterListReindexedHandler(SourceFilterListReindexed e);

public delegate void SourceFilterCreatedHandler(SourceFilterCreated e);

public delegate void SourceFilterRemovedHandler(SourceFilterRemoved e);

public delegate void SourceFilterNameChangedHandler(SourceFilterNameChanged e);

public delegate void SourceFilterEnableStateChangedHandler(SourceFilterEnableStateChanged e);

public delegate void SceneItemCreatedHandler(SceneItemCreated e);

public delegate void SceneItemRemovedHandler(SceneItemRemoved e);

public delegate void SceneItemListReindexedHandler(SceneItemListReindexed e);

public delegate void SceneItemEnableStateChangedHandler(SceneItemEnableStateChanged e);

public delegate void SceneItemLockStateChangedHandler(SceneItemLockStateChanged e);

public delegate void SceneItemSelectedHandler(SceneItemSelected e);

public delegate void SceneItemTransformChangedHandler(SceneItemTransformChanged e);

public delegate void StreamStateChangedHandler(StreamStateChanged e);

public delegate void RecordStateChangedHandler(RecordStateChanged e);

public delegate void ReplayBufferStateChangedHandler(ReplayBufferStateChanged e);

public delegate void VirtualcamStateChangedHandler(VirtualcamStateChanged e);

public delegate void ReplayBufferSavedHandler(ReplayBufferSaved e);

public delegate void MediaInputPlaybackStartedHandler(MediaInputPlaybackStarted e);

public delegate void MediaInputPlaybackEndedHandler(MediaInputPlaybackEnded e);

public delegate void MediaInputActionTriggeredHandler(MediaInputActionTriggered e);

public delegate void StudioModeStateChangedHandler(StudioModeStateChanged e);

#endregion

public sealed partial class ObsWebSocketClient
{
    #region Obs WebSocket Events

#pragma warning disable CS0067
    public event ExitStartedHandler? OnExitStarted;
    public event VendorEventHandler? OnVendorEvent;
    public event CurrentSceneCollectionChangingHandler? OnCurrentSceneCollectionChanging;
    public event CurrentSceneCollectionChangedHandler? OnCurrentSceneCollectionChanged;
    public event SceneCollectionListChangedHandler? OnSceneCollectionListChanged;
    public event CurrentProfileChangingHandler? OnCurrentProfileChanging;
    public event CurrentProfileChangedHandler? OnCurrentProfileChanged;
    public event ProfileListChangedHandler? OnProfileListChanged;
    public event SceneCreatedHandler? OnSceneCreated;
    public event SceneRemovedHandler? OnSceneRemoved;
    public event SceneNameChangedHandler? OnSceneNameChanged;
    public event CurrentProgramSceneChangedHandler? OnCurrentProgramSceneChanged;
    public event CurrentPreviewSceneChangedHandler? OnCurrentPreviewSceneChanged;
    public event SceneListChangedHandler? OnSceneListChanged;
    public event InputCreatedHandler? OnInputCreated;
    public event InputRemovedHandler? OnInputRemoved;
    public event InputNameChangedHandler? OnInputNameChanged;
    public event InputActiveStateChangedHandler? OnInputActiveStateChanged;
    public event InputShowStateChangedHandler? OnInputShowStateChanged;
    public event InputMuteStateChangedHandler? OnInputMuteStateChanged;
    public event InputVolumeChangedHandler? OnInputVolumeChanged;
    public event InputAudioBalanceChangedHandler? OnInputAudioBalanceChanged;
    public event InputAudioSyncOffsetChangedHandler? OnInputAudioSyncOffsetChanged;
    public event InputAudioTracksChangedHandler? OnInputAudioTracksChanged;
    public event InputAudioMonitorTypeChangedHandler? OnInputAudioMonitorTypeChanged;
    public event InputVolumeMetersHandler? OnInputVolumeMeters;
    public event CurrentSceneTransitionChangedHandler? OnCurrentSceneTransitionChanged;
    public event CurrentSceneTransitionDurationChangedHandler? OnCurrentSceneTransitionDurationChanged;
    public event SceneTransitionStartedHandler? OnSceneTransitionStarted;
    public event SceneTransitionEndedHandler? OnSceneTransitionEnded;
    public event SceneTransitionVideoEndedHandler? OnSceneTransitionVideoEnded;
    public event SourceFilterListReindexedHandler? OnSourceFilterListReindexed;
    public event SourceFilterCreatedHandler? OnSourceFilterCreated;
    public event SourceFilterRemovedHandler? OnSourceFilterRemoved;
    public event SourceFilterNameChangedHandler? OnSourceFilterNameChanged;
    public event SourceFilterEnableStateChangedHandler? OnSourceFilterEnableStateChanged;
    public event SceneItemCreatedHandler? OnSceneItemCreated;
    public event SceneItemRemovedHandler? OnSceneItemRemoved;
    public event SceneItemListReindexedHandler? OnSceneItemListReindexed;
    public event SceneItemEnableStateChangedHandler? OnSceneItemEnableStateChanged;
    public event SceneItemLockStateChangedHandler? OnSceneItemLockStateChanged;
    public event SceneItemSelectedHandler? OnSceneItemSelected;
    public event SceneItemTransformChangedHandler? OnSceneItemTransformChanged;
    public event StreamStateChangedHandler? OnStreamStateChanged;
    public event RecordStateChangedHandler? OnRecordStateChanged;
    public event ReplayBufferStateChangedHandler? OnReplayBufferStateChanged;
    public event VirtualcamStateChangedHandler? OnVirtualcamStateChanged;
    public event ReplayBufferSavedHandler? OnReplayBufferSaved;
    public event MediaInputPlaybackStartedHandler? OnMediaInputPlaybackStarted;
    public event MediaInputPlaybackEndedHandler? OnMediaInputPlaybackEnded;
    public event MediaInputActionTriggeredHandler? OnMediaInputActionTriggered;
    public event StudioModeStateChangedHandler? OnStudioModeStateChanged;
#pragma warning restore CS0067

    #endregion
}