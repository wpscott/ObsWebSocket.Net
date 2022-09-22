using System.Collections.ObjectModel;
using MessagePack;
using MessagePack.Formatters;
using ObsWebSocket.Net.Enums.Obs;

namespace ObsWebSocket.Net.Enums;

public class OutputFlagsFormatter : IMessagePackFormatter<IReadOnlyDictionary<ObsOutputFlags, bool>>
{
    public void Serialize(ref MessagePackWriter writer, IReadOnlyDictionary<ObsOutputFlags, bool> value,
        MessagePackSerializerOptions options)
    {
        writer.WriteMapHeader(value.Count);
        foreach (var pair in value)
        {
            writer.Write(pair.Key.ToString());
            writer.Write(pair.Value);
        }
    }

    public IReadOnlyDictionary<ObsOutputFlags, bool> Deserialize(ref MessagePackReader reader,
        MessagePackSerializerOptions options)
    {
        Dictionary<ObsOutputFlags, bool> result = new();
        var count = reader.ReadMapHeader();
        for (var i = 0; i < count; i++)
            result.Add(Enum.Parse<ObsOutputFlags>(reader.ReadString()), reader.ReadBoolean());

        return new ReadOnlyDictionary<ObsOutputFlags, bool>(result);
    }
}