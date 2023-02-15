using ToDo.DBL.Entities;
using ToDo.Utils;

namespace ToDo.Repositories.Implementation;

public class InXmlFileToDoRepository : IToDoRepository
{
    private readonly string _filePath;
    private readonly ILogger<InXmlFileToDoRepository> _logger;

    public InXmlFileToDoRepository(ILogger<InXmlFileToDoRepository> logger, IConfiguration config)
    {
        _logger = logger;
        _filePath = config.GetSection("StorageFilePath").Value;

        if (string.IsNullOrEmpty(_filePath))
        {
            throw new Exception("FilePath hasn't been found");
        }
    }


    public void Create(TodoItem toDoItem)
    {
        _logger.LogInformation($"Executing {nameof(Create)} method");
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);
        todoItemList.Add(toDoItem);
        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }

    public void Delete(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(Delete)} method. Trying to delete todoItem with id: {id}");
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);

        var todoItemToRemove = todoItemList.FirstOrDefault(item => item.Id == id);
        if (todoItemToRemove == null)
        {
            throw new Exception($"todoItemToRemove with id {id} hasn't been found");
        }

        todoItemList.Remove(todoItemToRemove);

        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }

    public TodoItem GetById(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(GetById)} method. Trying to get todoItem with id: {id}");
        return XmlParser<List<TodoItem>>.Read(_filePath).First(i => i.Id == id);
    }

    public List<TodoItem> GetList()
    {
        _logger.LogInformation($"Executing {nameof(GetList)} method");

        if (!File.Exists(_filePath))
        {
            var fs = File.Create(_filePath);
            fs.Close();
            XmlParser<List<TodoItem>>.Write(_filePath, new List<TodoItem>());
        }

        return XmlParser<List<TodoItem>>.Read(_filePath);
        
    }

    public void Update(Guid id, TodoItem toDoItem)
    {
        _logger.LogInformation($"Executing {nameof(Update)} method. Trying to update todoItem with id: {id}");
        List<TodoItem> todoItemList = XmlParser<List<TodoItem>>.Read(_filePath);

        foreach (var item in todoItemList)
        {
            if (item.Id == id)
            {
                item.Created = toDoItem.Created;
                item.IsDone = toDoItem.IsDone;
                item.Text = toDoItem.Text;
                item.Updated = DateTime.Now;
            }
        }

        XmlParser<List<TodoItem>>.Write(_filePath, todoItemList);
    }
}