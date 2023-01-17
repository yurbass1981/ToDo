using System.Xml.Serialization;
using ToDo.DTOs;
using ToDo.Utils;

namespace ToDo.Repositories.Implementation;

public class InXmlFileToDoRepository : IToDoRepository
{
    private readonly string _filePath;

    public InXmlFileToDoRepository(IConfiguration config)
    {
        _filePath = config.GetSection("StorageFilePath").Value;
        if (string.IsNullOrEmpty(_filePath))
        {
            throw new Exception("FilePath hasn't been found");
        }
    }


    public void Create(TodoItemDto toDoItem)
    {
        List<TodoItemDto> todoItemList = XmlParser<List<TodoItemDto>>.Read(_filePath);
        todoItemList.Add(toDoItem);
        XmlParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
    }

    public void Delete(Guid id)
    {
        List<TodoItemDto> todoItemList = XmlParser<List<TodoItemDto>>.Read(_filePath);

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

        XmlParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
    }


    // public TodoItemDto GetById(Guid id) => ReadListFromFile(FILE_PATH).First(i => i.Id == id);
    public TodoItemDto GetById(Guid id)
    {
        return XmlParser<List<TodoItemDto>>.Read(_filePath).First(i => i.Id == id);

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
        if (!File.Exists(_filePath))
        {
            var fs = File.Create(_filePath);
            fs.Close();
            XmlParser<List<TodoItemDto>>.Write(_filePath, new List<TodoItemDto>());
        }
        
        return XmlParser<List<TodoItemDto>>.Read(_filePath);
        //   List<TodoItemDto> todoItemList = ReadListFromFile(FILE_PATH);     
        //   return todoItemList;
    }

    public void Update(Guid id, TodoItemDto toDoItem)
    {
        List<TodoItemDto> todoItemList = XmlParser<List<TodoItemDto>>.Read(_filePath);

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

        XmlParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
    }
}