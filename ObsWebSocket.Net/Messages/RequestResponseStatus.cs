using System.Text.Json.Serialization;
using MessagePack;
using ObsWebSocket.Net.Protocol.Enums;

namespace ObsWebSocket.Net.Messages;

[MessagePackObject]
public class RequestResponseStatus
{
    /// <summary>
    ///     <see cref="Result" /> is <c>true</c> if the request resulted in
    ///     <see cref="RequestStatus.Success" />. False if otherwise.
    /// </summary>
    [JsonPropertyName("result")]
    [Key("result")]
    public bool Result { get; init; }

    [JsonPropertyName("code")]
    [Key("code")]
    public RequestStatus Code { get; init; }

    /// <summary>
    ///     <see cref="Comment" /> may be provided by the server on errors to offer further details on why a request
    ///     failed.
    /// </summary>
    [JsonPropertyName("comment")]
    [Key("comment")]
    public string? Comment { get; init; }
}