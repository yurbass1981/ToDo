using System.Text.Json;
using System.Text.Json.Serialization;

namespace ToDo.Utils
{
    public static class JsonParser<T>
    {
        public static T Read(string filePath)
        {
            T deserializedObject = default;

            using (var streamReader = new StreamReader(filePath))
            {
                var serializer = JsonSerializer.Serialize(typeof(T));
                deserializedObject = (T)JsonSerializer.Deserialize(streamReader);
            }
            return deserializedObject;
        }

        public static void Write(string filePath, T objectToSerialize)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                var serializer = JsonSerializer.Serialize(typeof(T));

                
            }
        }
        
    }
}