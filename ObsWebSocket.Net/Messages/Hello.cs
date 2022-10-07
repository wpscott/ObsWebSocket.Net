using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using MessagePack;

namespace ObsWebSocket.Net.Messages;

/// <summary>
///     <para>Sent from: obs-websocket</para>
///     <para>Sent to: Freshly connected websocket client</para>
///     <para>
///         Description: First message sent from the server immediately on client connection. Contains authentication
///         information if auth is required. Also contains RPC version for version negotiation.
///     </para>
/// </summary>
[MessagePackObject]
public class Hello
{
    [JsonPropertyName("obsWebSocketVersion")]
    [Key("obsWebSocketVersion")]
    public string ObsWebSocketVersion { get; init; } = null!;

    /// <summary>
    ///     <see cref="RpcVersion" /> is a version number which gets incremented on each breaking change to the
    ///     obs-websocket protocol. Its usage in this context is to provide the current rpc version that the server would like
    ///     to use.
    /// </summary>
    [JsonPropertyName("rpcVersion")]
    [Key("rpcVersion")]
    public int RpcVersion { get; init; }

    [JsonPropertyName("authentication")]
    [Key("authentication")]
    public HelloAuthentication? Authentication { get; init; }
}

/// <summary>
///     <para> To generate the authentication string, follow these steps:</para>
///     <para>
///         Concatenate the websocket password with the salt provided by the server
///         <c>(password + <see cref="Salt" />)</c>
///     </para>
///     <para>Generate an SHA256 binary hash of the result and base64 encode it, known as a base64 secret.</para>
///     <para>
///         Concatenate the base64 secret with the challenge sent by the server
///         <c>(base64_secret + <see cref="Challenge" />)</c>
///     </para>
///     <para>Generate a binary SHA256 hash of that result and base64 encode it. You now have your authentication string.</para>
/// </summary>
[MessagePackObject]
public class HelloAuthentication
{
    [JsonPropertyName("challenge")]
    [Key("challenge")]
    public string Challenge { get; init; } = null!;

    [JsonPropertyName("salt")]
    [Key("salt")]
    public string Salt { get; init; } = null!;

    public string? Authenticate(in string? password)
    {
        if (string.IsNullOrEmpty(password)) return null;
        using var sha256 = SHA256.Create();
        return
            Convert.ToBase64String(
                sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(
                        $"{Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes($"{password}{Salt}")))}{Challenge}")));
    }
}