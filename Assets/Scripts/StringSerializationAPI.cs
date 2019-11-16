using System;
using FullSerializer;

/// <summary>
/// API of the FullSerializer Library
/// </summary>

public static class StringSerializationAPI
{
    private static readonly fsSerializer Serializer = new fsSerializer();

    public static string Serialize(Type type, object value)
    {
        // serialize the data
        fsData data;
        Serializer.TrySerialize(type, value, out data).AssertSuccessWithoutWarnings();

        // emit the data via JSON
        return fsJsonPrinter.CompressedJson(data);
    }

    public static object Deserialize(Type type, string serializedState)
    {
        // step 1: parse the JSON data
        fsData data = fsJsonParser.Parse(serializedState);

        // step 2: deserialize the data
        object deserialized = null;
        Serializer.TryDeserialize(data, type, ref deserialized).AssertSuccessWithoutWarnings();

        return deserialized;
    }
}