using System.Xml.Serialization;
using ToDo.DTOs;

namespace ToDo.Repositories.Implementation;

public class InFileToDoRepository : IToDoRepository 
{
   private const string FILE_PATH = "Resources/data_storage.xml";


   public void Create(TodoItemDto toDoItem)
   {
      List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);
      todoItemList.Add(toDoItem);
      XmlParser.WriteListToFile(FILE_PATH, todoItemList);
   }
            
   public void Delete(Guid id)
   {
      List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);
      todoItemList.RemoveAll(item => item.Id == id);  

      //   foreach (var item in todoItemList)
      //   {
      //      if (item.Id == id)
      //      {
      //         todoItemList.Remove(item);
      //         break;
      //      }
      //   }

      WriteListToFile(FILE_PATH, todoItemList);
   }


   // public TodoItemDto GetById(Guid id) => ReadListFromFile(FILE_PATH).First(i => i.Id == id);
   public TodoItemDto GetById(Guid id)
   {
      return ReadListFromFile(FILE_PATH).First(i => i.Id == id);

      //   var todoList = ReadListFromFile(FILE_PATH);
      //   return todoList.First(item => item.Id == id);

      //   foreach (var item in todoList)
      //   {
      //      if (item.Id == id)
      //      {
      //         return item;
      //      }
      //   }

      //   throw new Exception($"TodoItem with id {id} hasn't been found");
   }

   public List<TodoItemDto> GetList()
   {
      return ReadListFromFile(FILE_PATH);
      //   List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);     
      //   return todoItemList;
   }

   public void Update(Guid id, TodoItemDto toDoItem)
   {
      List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);

      foreach (var item in todoItemList)
      {
         if (item.Id == id)
         {
            item.Created = toDoItem.Created;
            item.IsCompleted = toDoItem.IsCompleted;
            item.Text = toDoItem.Text;
            item.Updated = DateTime.Now;
         }
      }

      WriteListToFile(FILE_PATH, todoItemList);
   }


   // private List<TodoItemDto> ReadListFromFile(string filePath)
   // {
   //    List<TodoItemDto> todoItemList = null;

   //    using (var streamReader = new StreamReader(filePath))
   //    {
   //       var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
   //       todoItemList = serializer.Deserialize(streamReader) as List<TodoItemDto>;
   //    }

   //    return todoItemList;
   // }

   // private void WriteListToFile(string filePath, List<TodoItemDto> todoItems)
   // {
   //    using (var streamWriter = new StreamWriter(filePath))
   //    {
   //       var serializer = new XmlSerializer(typeof(List<TodoItemDto>));
   //       serializer.Serialize(streamWriter, todoItems);
   //    }
   // }
}