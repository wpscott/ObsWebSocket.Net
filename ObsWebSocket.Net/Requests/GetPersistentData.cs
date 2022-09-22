using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Enums;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Gets the value of a "slot" from the selected persistent data realm.
/// </summary>
[MessagePackObject]
public struct GetPersistentData
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
    public string SlotName { get; init; }
}

/// <summary>
///     Gets the value of a "slot" from the selected persistent data realm.
/// </summary>
[MessagePackObject]
public struct GetPersistentDataResponse
{
    /// <summary>
    ///     Value associated with the slot. <see langword="null" /> if not set
    /// </summary>
    [JsonPropertyName("slotValue")]
    [Key("slotValue")]
    public IReadOnlyDictionary<string, object>? SlotValue { get; init; }
}