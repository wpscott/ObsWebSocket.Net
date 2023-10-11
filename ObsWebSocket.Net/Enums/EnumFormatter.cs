using MessagePack;
using MessagePack.Formatters;

namespace ObsWebSocket.Net.Enums;

public class EnumFormatter<T> : IMessagePackFormatter<T> where T : struct, Enum
{
    public void Serialize(ref MessagePackWriter writer, T value, MessagePackSerializerOptions options)
    {
        writer.Write(value.ToString());
    }

    public T Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        return Enum.TryParse<T>(reader.ReadString() ?? string.Empty, out var @enum) ? @enum : default;
    }
}

public class NullableEnumFormatter<T> : IMessagePackFormatter<T?> where T : struct, Enum
{
    public void Serialize(ref MessagePackWriter writer, T? value, MessagePackSerializerOptions options)
    {
        writer.Write(value?.ToString());
    }

    public T? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        var str = reader.ReadString();
        if (string.IsNullOrEmpty(str)) return null;
        return Enum.TryParse<T>(str, out var @enum) ? @enum : default;
    }
}