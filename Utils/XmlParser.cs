using System.Xml.Serialization;

namespace ToDo.Utils;

public static class XmlParser<T>
{
    public static T Read(string filePath)
    {
        T deserializedObject = default;

        using (var streamReader = new StreamReader(filePath))
        {
            var serializer = new XmlSerializer(typeof(T));
            deserializedObject = (T)serializer.Deserialize(streamReader);
        }

        return deserializedObject;
    }

    public static void Write(string filePath, T objectToSerialize)
    {
        using (var streamWriter = new StreamWriter(filePath))
        {
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(streamWriter, objectToSerialize);
        }
    }
}
