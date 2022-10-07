using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Requests;

/// <summary>
///     Call a request registered to a vendor.
///     <remarks>
///         A vendor is a unique name registered by a third-party plugin or script, which allows for custom requests
///         and events to be added to obs-websocket. If a plugin or script implements vendor requests or events,
///         documentation is expected to be provided with them.
///     </remarks>
/// </summary>
[MessagePackObject]
public class CallVendorRequest
{
    /// <summary>
    ///     Name of the vendor to use
    /// </summary>
    [JsonPropertyName("vendorName")]
    [Key("vendorName")]
    public string VendorName { get; init; } = null!;

    /// <summary>
    ///     The request type to call
    /// </summary>
    [JsonPropertyName("requestType")]
    [Key("requestType")]
    public string RequestType { get; init; } = null!;

    /// <summary>
    ///     Object containing appropriate request data
    /// </summary>
    [JsonPropertyName("requestData")]
    [Key("requestData")]
    public IDictionary<string, object>? RequestData { get; init; }
}

[MessagePackObject]
public class CallVendorRequestResponse
{
    /// <summary>
    ///     Echoed of <see cref="CallVendorRequest.VendorName" />
    /// </summary>
    [JsonPropertyName("vendorName")]
    [Key("vendorName")]
    public string VendorName { get; init; } = null!;

    /// <summary>
    ///     Echoed of <see cref="CallVendorRequest.RequestType" />
    /// </summary>
    [JsonPropertyName("requestType")]
    [Key("requestType")]
    public string RequestType { get; init; } = null!;

    /// <summary>
    ///     Object containing appropriate response data. <c>{}</c> if request does not provide any response data
    /// </summary>
    [JsonPropertyName("responseData")]
    [Key("responseData")]
    public IReadOnlyDictionary<string, object>? ResponseData { get; init; }
}