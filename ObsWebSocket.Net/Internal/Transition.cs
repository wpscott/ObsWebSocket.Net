using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public struct Transition
{
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; }

    [JsonPropertyName("transitionKind")]
    [Key("transitionKind")]
    public string TransitionKind { get; init; }

    [JsonPropertyName("transitionFixed")]
    [Key("transitionFixed")]
    public bool TransitionFixed { get; init; }

    [JsonPropertyName("transitionConfigurable")]
    [Key("transitionConfigurable")]
    public bool TransitionConfigurable { get; init; }
}