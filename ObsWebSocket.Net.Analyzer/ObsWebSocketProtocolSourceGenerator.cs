using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;
using ObsWebSocket.Net.Analyzer.Protocol;
using Enum = ObsWebSocket.Net.Analyzer.Protocol.Enum;

namespace ObsWebSocket.Net.Analyzer;

[Generator]
public class ObsWebSocketProtocolSourceGenerator : ISourceGenerator
{
    private static readonly Regex QuoteRegex = new(@"`([\d\w_]+)`", RegexOptions.Compiled);

    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var protocol = context.AdditionalFiles.FirstOrDefault(file => file.Path.EndsWith("protocol.json"));
        var text = protocol?.GetText();
        if (text == null) return;
        var json = JsonConvert.DeserializeObject<ObsWebSocketProtocol>(text.ToString());
        if (json == null) return;

        GenerateEnums(context, json.Enums);
        GenerateEvents(context, json.Events);
        GenerateRequests(context, json.Requests);
    }


    private static IEnumerable<string> GenerateClassDescriptions(string description)
    {
        return GenerateValueDescription(description)
            .Replace("\n\n", "|")
            .Replace("\n", " ")
            .Split('|');
    }

    private static string GenerateValueDescription(string description)
    {
        return QuoteRegex
            .Replace(
                description.Replace("<", "&lt;").Replace(">", "&gt;").Replace("`null`", """<see langword="null"/>"""),
                "<c>$0</c>")
            .Replace("`", string.Empty);
    }

    private static string ConvertValueType(Field field)
    {
        return field.ValueName switch
        {
            "monitorType" => "ObsMonitoringType",
            "mediaAction" =>
                "ObsMediaInputAction",
            "sceneItemTransform" => "SceneItemTransform ",
            "mediaState" => "ObsMediaState",
            "realm" => "ObsWebSocketDataRealm",
            "sceneItemBlendMode" => "ObsBlendingType",
            "propertyItems" => "IReadOnlyList<InputPropertyItem>",
            "videoMixType" => "ObsWebSocketVideoMixType",
            "keyId" => "ObsHotKeys",
            "keyModifiers" => "KeyModifiers",
            _ => field.ValueType switch
            {
                "Any" => "IDictionary<string, object>",
                "String" => "string",
                "Object" => "IDictionary<string, object>",
                "Boolean" => "bool",
                "Number" => field.ValueName switch
                {
                    "transitionDuration" => "ulong",
                    "inputAudioSyncOffset" => "ulong",
                    "sceneItemId" => "ulong",
                    "mediaCursor" => "ulong",
                    "inputAudioBalance" => "double",
                    "inputVolumeMul" => "double",
                    "inputVolumeDb" => "double",
                    "position" => "double",
                    "outputCongestion" => "double",
                    "sceneItemIndex" => "int",
                    "filterIndex" => "int",
                    "imageHeight" => "ushort",
                    "imageWidth" => "ushort",
                    "imageCompressionQuality" => "sbyte",
                    _ => "double"
                },
                "Array<Object>" => "IReadOnlyList<" + field.ValueName.Substring(0, 1).ToUpper() +
                                   field.ValueName.Substring(1, field.ValueName.Length - 2) +
                                   ">",
                "Array<String>" => "string[]",
                _ => throw new ArgumentOutOfRangeException(nameof(field.ValueType), field.ValueType,
                    "Unknown value type")
            }
        };
    }

    private static string GenerateDataField(Field field)
    {
        return field.ValueName switch
        {
            //"monitorType" => "public ObsMonitoringType MonitorType { get; init; }",
            //"mediaAction" =>
            //    "public ObsMediaInputAction WebSocketMediaInputAction { get; init; }",
            //"sceneItemTransform" => "public SceneItemTransform SceneItemTransform { get; init; }",
            //"mediaState" => "public ObsMediaState MediaState { get; init; }",
            //"realm" => "public ObsWebSocketDataRealm Realm { get; init; }",
            //"sceneItemBlendMode" => "public ObsBlendingType SceneItemBlendMode { get; init; }",
            //"propertyItems" => "public IReadOnlyList<InputPropertyItem> PropertyItems { get; init; }",
            //"videoMixType" => "public ObsWebSocketVideoMixType VideoMixType { get; init; }",
            //"keyId" => "public ObsHotKeys? KeyId { get; init; }",
            "keyModifiers.shift" => "public bool? Shift { get; init; }",
            "keyModifiers.control" => "public bool? control { get; init; }",
            "keyModifiers.alt" => "public bool? alt { get; init; }",
            "keyModifiers.command" => "public bool? command { get; init; }",
            _ => "public " + ConvertValueType(field) +
                 (field is RequestField requestField ? requestField.ValueOptional ? "? " : " " : " ") +
                 field.ValueName.Substring(0, 1).ToUpper() + field.ValueName.Substring(1) + " { get; init; }"
        };
    }

    private static void GenerateEnums(in GeneratorExecutionContext context, in IEnumerable<Enum> enums)
    {
        var enumsSb = new StringBuilder();

        enumsSb.AppendLine("""
                           // <auto-generated/>

                           using System.Text.Json.Serialization;

                           namespace ObsWebSocket.Net.Protocol.Enums;

                           """);
        foreach (var @enum in enums)
        {
            var enumSb = new StringBuilder();
            switch (@enum.EnumType)
            {
                case "EventSubscription":
                    enumSb.AppendLine("[Flags]");
                    goto default;
                case "RequestBatchExecutionType":
                    enumSb.AppendLine($"public enum {@enum.EnumType} : sbyte");
                    break;
                case "WebSocketOpCode":
                    enumSb.AppendLine($"public enum {@enum.EnumType} : byte");
                    break;
                case "ObsOutputState":
                case "ObsMediaInputAction":
                    enumSb.AppendLine("""
                                      [Obsolete("Deprecated")]
                                      [JsonConverter(typeof(JsonStringEnumConverter))]
                                      """);
                    goto default;
                default:
                    enumSb.AppendLine($"public enum {@enum.EnumType}");
                    break;
            }

            enumSb.AppendLine("{");

            foreach (var identifier in @enum.EnumIdentifiers)
            {
                if (!string.IsNullOrEmpty(identifier.Description))
                {
                    enumSb.AppendLine("    /// <summary>");
                    var descriptions = GenerateClassDescriptions(identifier.Description);

                    foreach (var desc in descriptions)
                        enumSb.AppendLine(desc.StartsWith("Note:")
                            ? $"    /// <remarks>{desc}</remarks>"
                            : $"    /// <para>{desc}</para>");

                    enumSb.AppendLine($"""
                                          /// <para>
                                          /// Latest Supported RPC Version: {identifier.RpcVersion}
                                          /// <br/>
                                          /// Added in v{identifier.InitialVersion}
                                          /// </para>
                                       """);
                    enumSb.AppendLine("    /// </summary>");
                }

                if (identifier.Deprecated) enumSb.AppendLine("    [Obsolete(\"Deprecated\")]");

                enumSb.AppendLine(identifier.EnumIdentifierEnumIdentifier == identifier.EnumValue
                    ? $"    {identifier.EnumIdentifierEnumIdentifier},"
                    : $"    {identifier.EnumIdentifierEnumIdentifier} = {identifier.EnumValue},");
            }

            enumSb.AppendLine("}");

            enumsSb.AppendLine(enumSb.ToString());
        }

        context.AddSource("ObsWebSocket_Enums.g.cs", SourceText.From(enumsSb.ToString(), Encoding.UTF8));
    }

    private static void GenerateEvents(in GeneratorExecutionContext context, in IEnumerable<Event> events)
    {
        var enumsSb = new StringBuilder();
        enumsSb.AppendLine("""
                           // <auto-generated/>

                           using System.Text.Json.Serialization;

                           namespace ObsWebSocket.Net.Protocol.Enums;

                           [JsonConverter(typeof(JsonStringEnumConverter))]
                           public enum EventType : byte
                           {
                           """);

        var eventsSb = new StringBuilder();
        eventsSb.AppendLine("""
                            // <auto-generated/>

                            using System.Text.Json.Serialization;
                            using MessagePack;
                            using ObsWebSocket.Net.Enums;
                            using ObsWebSocket.Net.Enums.Obs;
                            using ObsWebSocket.Net.Protocol.Enums;
                            using ObsWebSocket.Net.Internal;

                            namespace ObsWebSocket.Net.Protocol.Events;

                            """);

        var delegateSb = new StringBuilder();
        delegateSb.AppendLine("""
                              // <auto-generated/>
                              #nullable enable
                              using ObsWebSocket.Net.Protocol.Events;

                              namespace ObsWebSocket.Net.Protocol;

                              """);

        var clientEventsSb = new StringBuilder();
        clientEventsSb.AppendLine("#pragma warning disable CS0067");

        var clientSb = new StringBuilder();
        var json = new StringBuilder();
        var msgpack = new StringBuilder();

        clientSb.AppendLine("""
                            // <auto-generated/>
                            #nullable enable
                            using System.Text.Json;
                            using MessagePack;
                            using ObsWebSocket.Net.Protocol;
                            using ObsWebSocket.Net.Protocol.Enums;
                            using ObsWebSocket.Net.Protocol.Events;
                            using JsonEvent = ObsWebSocket.Net.Messages.Json.Event;
                            using MsgPackEvent = ObsWebSocket.Net.Messages.MsgPack.Event;

                            namespace ObsWebSocket.Net;

                            public sealed partial class ObsWebSocketClient
                            {
                            """);
        json.AppendLine("""
                            private partial void HandleEvents(in JsonEvent? evt)
                            {
                                if (evt == null) return;
                        
                                switch(evt.EventType)
                                {
                        """);
        msgpack.AppendLine("""
                           
                               private partial void HandleEvents(in MsgPackEvent? evt)
                               {
                                   if (evt == null) return;
                           
                                   switch(evt.EventType)
                                   {
                           """);

        foreach (var @event in events)
        {
            enumsSb.AppendLine($"    {@event.EventType},");

            #region Event

            var eventSb = new StringBuilder();

            if (!string.IsNullOrEmpty(@event.Description))
            {
                eventSb.AppendLine("/// <summary>");
                var descriptions = GenerateClassDescriptions(@event.Description);
                foreach (var desc in descriptions)
                    eventSb.AppendLine(desc.StartsWith("Note:")
                        ? $"/// <remarks>{desc}</remarks>"
                        : $"/// <para>{desc}</para>");

                eventSb.AppendLine($"""
                                    /// <para>
                                    /// Complexity Rating: {@event.Complexity}/5
                                    /// <br/>
                                    /// Latest Supported RPC Version: {@event.RpcVersion}
                                    /// <br/>
                                    /// Added in v{@event.InitialVersion}
                                    /// </para>
                                    """);

                eventSb.AppendLine("/// </summary>");
            }

            if (@event.Deprecated) eventSb.AppendLine("[Obsolete(\"Deprecated\")]");

            eventSb.AppendLine($$"""
                                 [MessagePackObject]
                                 public sealed class {{@event.EventType}}
                                 {
                                 """);
            foreach (var field in @event.DataFields)
                eventSb.AppendLine($"""
                                        /// <value>
                                        ///     {field.ValueDescription}
                                        /// </value>
                                        [JsonPropertyName("{field.ValueName}")]
                                        [Key("{field.ValueName}")]
                                        {GenerateDataField(field)}
                                        
                                    """);

            eventSb.AppendLine("}");

            eventsSb.AppendLine(eventSb.ToString());

            #endregion

            #region Delegates

            delegateSb.AppendLine(
                $"public delegate void {@event.EventType}Handler({(@event.EventType == "ExitStarted" ? "" : @event.EventType + "? e")});");
            clientEventsSb.AppendLine($"    public event {@event.EventType}Handler? On{@event.EventType};");

            #endregion

            #region Class Handlers

            json.AppendLine($"            case EventType.{@event.EventType}:");
            json.Append($"                On{@event.EventType}");
            msgpack.AppendLine($"            case EventType.{@event.EventType}:");
            msgpack.Append($"                On{@event.EventType}");
            if (@event.EventType != "ExitStarted")
            {
                json.AppendLine($"?.Invoke(evt.EventData.Deserialize<{@event.EventType}>());");
                msgpack.AppendLine(
                    $"?.Invoke(MessagePackSerializer.Deserialize<{@event.EventType}>(MessagePackSerializer.Serialize(evt.EventData)));");
            }
            else
            {
                json.AppendLine("?.Invoke();");
                msgpack.AppendLine("?.Invoke();");
            }

            json.AppendLine("                break;");
            msgpack.AppendLine("                break;");

            #endregion
        }

        enumsSb.AppendLine("}");
        context.AddSource("ObsWebSocket_EventTypes.g.cs", SourceText.From(enumsSb.ToString(), Encoding.UTF8));

        context.AddSource("ObsWebSocket_Events.g.cs", SourceText.From(eventsSb.ToString(), Encoding.UTF8));

        clientEventsSb.AppendLine("#pragma warning restore CS0067");

        context.AddSource("ObsWebSocket_EventDelegates.g.cs",
            SourceText.From(delegateSb.ToString(), Encoding.UTF8));

        json.AppendLine("""
                                    default: break;
                                }
                            }
                        """);
        msgpack.AppendLine("""
                                       default: break;
                                   }
                               }
                           """);
        clientSb.Append(clientEventsSb);
        clientSb.Append(json);
        clientSb.Append(msgpack);
        clientSb.AppendLine("}");

        context.AddSource("ObsWebSocketClient_EventHandlers.g.cs",
            SourceText.From(clientSb.ToString(), Encoding.UTF8));
    }

    private static void GenerateRequests(in GeneratorExecutionContext context, in IEnumerable<Request> requests)
    {
        var enumsSb = new StringBuilder();
        enumsSb.AppendLine("""
                           // <auto-generated/>

                           using System.Text.Json.Serialization;

                           namespace ObsWebSocket.Net.Protocol.Enums;

                           [JsonConverter(typeof(JsonStringEnumConverter))]
                           public enum RequestType : byte
                           {
                           """);

        var requestsSb = new StringBuilder();
        requestsSb.AppendLine("""
                              // <auto-generated/>
                              #nullable enable
                              using System.Text.Json.Serialization;
                              using MessagePack;
                              using ObsWebSocket.Net.Enums;
                              using ObsWebSocket.Net.Enums.Obs;
                              using ObsWebSocket.Net.Protocol.Enums;
                              using ObsWebSocket.Net.Protocol.Events;
                              using ObsWebSocket.Net.Internal;
                              using Monitor = ObsWebSocket.Net.Internal.Monitor;

                              namespace ObsWebSocket.Net.Protocol.Requests;

                              """);

        var clientSb = new StringBuilder();
        clientSb.AppendLine("""
                            // <auto-generated/>
                            #nullable enable
                            using System.Text.Json;
                            using MessagePack;
                            using ObsWebSocket.Net.Enums;
                            using ObsWebSocket.Net.Enums.Obs;
                            using ObsWebSocket.Net.Internal;
                            using ObsWebSocket.Net.Protocol.Enums;
                            using ObsWebSocket.Net.Protocol.Requests;
                            using JsonRequestResponse = ObsWebSocket.Net.Messages.Json.RequestResponse;
                            using MsgPackRequestResponse = ObsWebSocket.Net.Messages.MsgPack.RequestResponse;

                            namespace ObsWebSocket.Net;

                            public sealed partial class ObsWebSocketClient
                            {
                            """);

        var json = new StringBuilder();
        var msgpack = new StringBuilder();
        json.AppendLine(
            """
                private static partial object? DeserializeRequestResponse(in JsonRequestResponse? response)
                {
                    if (response == null || response.ResponseData == null) return null;
                    switch(response.RequestType)
                    {
            """);
        msgpack.AppendLine("""
                           
                               private static partial object? DeserializeRequestResponse(in MsgPackRequestResponse? response)
                               {
                                   if (response == null || response.ResponseData == null) return null;
                                   switch(response.RequestType)
                                   {
                           """);

        var newRequestSb = new StringBuilder();

        foreach (var request in requests)
        {
            enumsSb.AppendLine($"    {request.RequestType},");

            #region Request

            var requestSb = new StringBuilder();

            if (!string.IsNullOrEmpty(request.Description))
            {
                requestSb.AppendLine("/// <summary>");

                var descriptions = GenerateClassDescriptions(request.Description);

                foreach (var desc in descriptions)
                    requestSb.AppendLine(desc.StartsWith("Note:")
                        ? $"/// <remarks>{desc}</remarks>"
                        : $"/// <para>{desc}</para>");

                requestSb.AppendLine($"""
                                      /// <remarks>
                                      /// <para>
                                      /// Complexity Rating: {request.Complexity}/5
                                      /// <br/>
                                      /// Latest Supported RPC Version: {request.RpcVersion}
                                      /// <br/>
                                      /// Added in v{request.InitialVersion}
                                      /// </para>
                                      /// </remarks>
                                      """);
                requestSb.AppendLine("/// </summary>");
            }

            if (request.Deprecated) requestSb.AppendLine("[Obsolete(\"Deprecated\")]");

            switch (request.RequestType)
            {
                case "TriggerHotkeyByKeySequence":
                {
                    const string modifier = "keyModifiers.";

                    requestSb.AppendLine("""
                                         [MessagePackObject]
                                         public sealed class KeyModifiers
                                         {
                                         """);
                    foreach (var f in request.RequestFields.Where(keyField =>
                                 keyField.ValueName.StartsWith(modifier)))
                        requestSb.AppendLine($"""
                                                  /// <value>
                                                  ///     {GenerateValueDescription(f.ValueDescription)}
                                                  /// </value>
                                                  [JsonPropertyName("{f.ValueName.Substring(modifier.Length)}")]
                                                  [Key("{f.ValueName.Substring(modifier.Length)}")]
                                                  {GenerateDataField(f)}
                                                  
                                              """);

                    requestSb.AppendLine("}");
                    break;
                }
                case "GetInputPropertiesListPropertyItems":
                    requestSb.AppendLine("""
                                         [MessagePackObject]
                                         public class InputPropertyItem
                                         {
                                             [JsonPropertyName("itemName")]
                                             [Key("itemName")]
                                             public string ItemName { get; init; } = null!;
                                         
                                             [JsonPropertyName("itemEnabled")]
                                             [Key("itemEnabled")]
                                             public bool ItemEnabled { get; init; }
                                         
                                             /// <value>
                                             ///     <see langword="long" />, <see langword="double" /> or <see langword="string" />
                                             /// </summary>
                                             [JsonPropertyName("itemValue")]
                                             [Key("itemValue")]
                                             public object? ItemValue { get; init; }
                                         }
                                         """);
                    break;
            }

            if (request.RequestFields.Length > 0)
            {
                requestSb.AppendLine($$"""
                                       [MessagePackObject]
                                       public sealed class {{request.RequestType}}
                                       {
                                       """);

                foreach (var field in request.RequestFields)
                {
                    if (field.ValueName == "keyModifiers")
                    {
                        requestSb.AppendLine($$"""
                                                   /// <value>
                                                   ///     {{GenerateValueDescription(field.ValueDescription)}}
                                                   /// </value>
                                                   [JsonPropertyName("{{field.ValueName}}")]
                                                   [Key("{{field.ValueName}}")]
                                                   public KeyModifiers? KeyModifiers { get; init; }

                                               """);

                        break;
                    }

                    requestSb.AppendLine($"""
                                              /// <value>
                                              ///     {GenerateValueDescription(field.ValueDescription)}
                                              /// </value>
                                              [JsonPropertyName("{field.ValueName}")]
                                              [Key("{field.ValueName}")]
                                              {GenerateDataField(field)}
                                              
                                          """);
                }

                requestSb.AppendLine("}");
            }

            if (request.ResponseFields.Length > 0)
            {
                requestSb.AppendLine($$"""
                                       [MessagePackObject]
                                       public sealed class {{request.RequestType + "Response"}}
                                       {
                                       """);
                foreach (var field in request.ResponseFields)
                    requestSb.AppendLine($"""
                                              /// <value>
                                              ///     {GenerateValueDescription(field.ValueDescription)}
                                              /// </value>
                                              [JsonPropertyName("{field.ValueName}")]
                                              [Key("{field.ValueName}")]
                                              {GenerateDataField(field)}
                                              
                                          """);

                requestSb.AppendLine("}");
            }

            requestsSb.AppendLine(requestSb.ToString());

            #endregion

            #region Functions

            newRequestSb.Clear();
            clientSb.Append("    public ");
            var hasRequest = request.RequestFields.Length > 0;
            var hasResponse = request.ResponseFields.Length > 0;
            clientSb.Append(hasResponse
                ? $"Task<{request.RequestType}Response?> {request.RequestType}"
                : $"void {request.RequestType}");

            clientSb.Append("(");
            if (hasRequest)
            {
                clientSb.Append(string.Join(", ",
                    request.RequestFields
                        .Where(field =>
                            field.ValueName != "keyModifiers.shift" && field.ValueName != "keyModifiers.control" &&
                            field.ValueName != "keyModifiers.alt" && field.ValueName != "keyModifiers.command")
                        .Select(field => $"{ConvertValueType(field)} {field.ValueName}")));

                newRequestSb.AppendLine($", new {request.RequestType} {{ ");
                newRequestSb.AppendLine(string.Join(",\r\n",
                    request.RequestFields
                        .Where(field =>
                            field.ValueName != "keyModifiers.shift" && field.ValueName != "keyModifiers.control" &&
                            field.ValueName != "keyModifiers.alt" && field.ValueName != "keyModifiers.command")
                        .Select(field =>
                            $"            {field.ValueName.Substring(0, 1).ToUpper() + field.ValueName.Substring(1)} = {field.ValueName}")));
                newRequestSb.Append("        }");
            }

            clientSb.AppendLine(")");
            clientSb.AppendLine("    {");
            clientSb.Append(hasResponse
                ? $"        return Invoke<{request.RequestType}Response>(RequestType."
                : "        Send(RequestType.");

            clientSb.Append(request.RequestType);
            clientSb.Append(newRequestSb);
            clientSb.AppendLine(");");
            clientSb.AppendLine("    }");
            clientSb.AppendLine();

            #endregion

            #region Client DeserializaRequestResponse

            json.AppendLine($"            case RequestType.{request.RequestType}:");
            msgpack.AppendLine($"            case RequestType.{request.RequestType}:");
            if (request.ResponseFields.Length == 0)
            {
                json.AppendLine("                return null;");
                msgpack.AppendLine("                return null;");
            }
            else
            {
                json.AppendLine(
                    $"                return response.ResponseData.Deserialize<{request.RequestType}Response>();");
                msgpack.AppendLine(
                    $"                return MessagePackSerializer.Deserialize<{request.RequestType}Response>(MessagePackSerializer.Serialize(response.ResponseData));");
            }

            #endregion
        }

        enumsSb.AppendLine("}");
        context.AddSource("ObsWebSocket_RequestTypes.g.cs", SourceText.From(enumsSb.ToString(), Encoding.UTF8));

        context.AddSource("ObsWebSocket_Requests.g.cs", SourceText.From(requestsSb.ToString(), Encoding.UTF8));

        json.AppendLine("""
                                    default: return null;
                                }
                            }
                        """);
        msgpack.AppendLine("""
                                       default: return null;
                                   }
                               }
                           """);
        clientSb.Append(json);
        clientSb.Append(msgpack);
        clientSb.AppendLine("}");
        context.AddSource("ObsWebSocketClient_RequestFunctions.g.cs",
            SourceText.From(clientSb.ToString(), Encoding.UTF8));
    }
}