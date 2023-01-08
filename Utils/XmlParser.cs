using System;
using System.Xml.Serialization;
using ToDo.DTOs;

namespace ToDo.Utils
{
    public static class XmlParser
    {
        public static List<TodoItemDto> ReadListFromFile(string filePath)
        {
            List<TodoItemDto> todoItemList = null;

            using (var streamReader = new StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
                todoItemList = serializer.Deserialize(streamReader) as List<TodoItemDto>;
            }

            return todoItemList;
        }

        public static void WriteListToFile(string filePath, List<TodoItemDto> todoItems)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
                serializer.Serialize(streamWriter, todoItems);
            }
        }
    }
}