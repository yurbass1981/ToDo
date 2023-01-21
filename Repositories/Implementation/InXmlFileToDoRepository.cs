using ToDo.Entities;
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


    public void Create(TodoItem toDoItem)
    {
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);
        todoItemList.Add(toDoItem);
        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }

    public void Delete(Guid id)
    {
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);

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

        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }


    // public TodoItem GetById(Guid id) => ReadListFromFile(FILE_PATH).First(i => i.Id == id);
    public TodoItem GetById(Guid id)
    {
        return XmlParser<List<TodoItem>>.Read(_filePath).First(i => i.Id == id);

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

    public List<TodoItem> GetList()
    {
        if (!File.Exists(_filePath))
        {
            var fs = File.Create(_filePath);
            fs.Close();
            XmlParser<List<TodoItem>>.Write(_filePath, new List<TodoItem>());
        }
        
        return XmlParser<List<TodoItem>>.Read(_filePath);
        //   List<TodoItem> todoItemList = ReadListFromFile(FILE_PATH);     
        //   return todoItemList;
    }

    public void Update(Guid id, TodoItem toDoItem)
    {
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);

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

        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }
}