﻿using MessagePack;
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
        return Enum.Parse<T>(reader.ReadString());
    }
}