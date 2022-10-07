using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Internal;

[MessagePackObject]
public class Transition
{
    [JsonPropertyName("transitionName")]
    [Key("transitionName")]
    public string TransitionName { get; init; } = null!;

    [JsonPropertyName("transitionKind")]
    [Key("transitionKind")]
    public string TransitionKind { get; init; } = null!;

    [JsonPropertyName("transitionFixed")]
    [Key("transitionFixed")]
    public bool TransitionFixed { get; init; }

    [JsonPropertyName("transitionConfigurable")]
    [Key("transitionConfigurable")]
    public bool TransitionConfigurable { get; init; }
}