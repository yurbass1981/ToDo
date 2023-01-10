using System.Xml.Serialization;
using ToDo.DTOs;
using ToDo.Utils;

namespace ToDo.Repositories.Implementation;

public class InFileToDoRepository : IToDoRepository 
{
   private const string FILE_PATH = "Resources/data_storage.xml";


   public void Create(TodoItemDto toDoItem)
   {
      List<TodoItemDto> todoItemList = XmlParser.ReadListFromFile(FILE_PATH);
      todoItemList.Add(toDoItem);
      XmlParser.WriteListToFile(FILE_PATH, todoItemList);
   }
            
   public void Delete(Guid id)
   {
      List<TodoItemDto> todoItemList = XmlParser.ReadListFromFile(FILE_PATH);

      var todoItemToRemove = todoItemList.FirstOrDefault(item => item.Id == id);
      if (todoItemToRemove == null)
      {
         throw new Exception($"todoItemToRemove whith id {id} hasn't been found");
      }

      todoItemList.Remove(todoItemToRemove);


      // todoItemList.RemoveAll(item => item.Id == id);  

      //   foreach (var item in todoItemList)
      //   {
      //      if (item.Id == id)
      //      {
      //         todoItemList.Remove(item);
      //         break;
      //      }
      //   }

      XmlParser.WriteListToFile(FILE_PATH, todoItemList);
   }


   // public TodoItemDto GetById(Guid id) => ReadListFromFile(FILE_PATH).First(i => i.Id == id);
   public TodoItemDto GetById(Guid id)
   {
      return XmlParser.ReadListFromFile(FILE_PATH).First(i => i.Id == id);

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
      return XmlParser.ReadListFromFile(FILE_PATH);
      //   List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);     
      //   return todoItemList;
   }

   public void Update(Guid id, TodoItemDto toDoItem)
   {
      List<TodoItemDto> todoItemList = XmlParser.ReadListFromFile(FILE_PATH);

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

      XmlParser.WriteListToFile(FILE_PATH, todoItemList);
   }
}