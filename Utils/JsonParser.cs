using System.Text.Json;

namespace ToDo.Utils;

public static class JsonParser<T>
{
    public static T Read(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static void Write(string filePath, T objectToSerialize)
    {
        var jsonString = JsonSerializer.Serialize<T>(objectToSerialize, new JsonSerializerOptions()
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, jsonString);
    }
}