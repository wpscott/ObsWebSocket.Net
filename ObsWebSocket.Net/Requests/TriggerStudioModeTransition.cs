using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Triggers the current scene transition. Same functionality as the <c>Transition</c> button in studio mode.
/// </summary>
[MessagePackObject]
public struct TriggerStudioModeTransition
{
}