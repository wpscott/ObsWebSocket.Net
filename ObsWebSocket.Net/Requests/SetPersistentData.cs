using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Sets the value of a "slot" from the selected persistent data realm.
/// </summary>
[MessagePackObject]
public class SetPersistentData
{
    /// <summary>
    ///     The data realm to select.
    ///     <see cref="ObsWebSocketDataRealm.OBS_WEBSOCKET_DATA_REALM_GLOBAL" /> or
    ///     <see cref="ObsWebSocketDataRealm.OBS_WEBSOCKET_DATA_REALM_PROFILE" />
    /// </summary>
    [JsonPropertyName("realm")]
    [Key("realm")]
    [MessagePackFormatter(typeof(EnumFormatter<ObsWebSocketDataRealm>))]
    public ObsWebSocketDataRealm Realm { get; init; }

    /// <summary>
    ///     The name of the slot to retrieve data from
    /// </summary>
    [JsonPropertyName("slotName")]
    [Key("slotName")]
    public string SlotName { get; init; } = null!;

    /// <summary>
    ///     The value to apply to the slot
    /// </summary>
    [JsonPropertyName("slotValue")]
    [Key("slotValue")]
    public IDictionary<string, object>? SlotValue { get; init; }
}