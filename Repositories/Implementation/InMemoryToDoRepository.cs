using ToDo.DBL.Entities;

namespace ToDo.Repositories.Implementation;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<TodoItem> _todoStorage = new();
    private readonly ILogger<InMemoryToDoRepository> _logger;

    public void Create(TodoItem toDoItem)
    {
        _logger.LogInformation($"Executing {nameof(Create)} method");
        _todoStorage.Add(toDoItem);
    }

    public void Delete(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(Delete)} method. Trying to delete todoItem with id: {id}");

        TodoItem toDoItemToDelete = _todoStorage.FirstOrDefault(item => item.Id == id);
        if (toDoItemToDelete == null)
        {
            throw new Exception($"toDoItemToDelete with id {id} hasn't been found");
        }

        // TodoItem todoItemToDelete = null;
        // foreach (var item in _todoStorage)
        // {
        //     if (item.Id == id)
        //     {
        //         toDoItemToDelete = item;
        //         break;
        //     }
        // }

        _todoStorage.Remove(toDoItemToDelete);
    }

    public TodoItem GetById(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(GetById)} method. Trying to get todoItem with id: {id}");
        return _todoStorage.FirstOrDefault(ti => ti.Id == id);
    }

    public List<TodoItem> GetList()
    {
        _logger.LogInformation($"Executing {nameof(GetList)} method");
        return _todoStorage.OrderByDescending(ti => ti.Created).ToList();
    }

    public void Update(Guid id, TodoItem toDoItem)
    {
        _logger.LogInformation($"Executing {nameof(Update)} method. Trying to update todoItem with id: {id}");
        
        var itemToUpdate = GetById(id);

        if (itemToUpdate != null)
        {
            itemToUpdate.Text = toDoItem.Text;
            itemToUpdate.IsDone = toDoItem.IsDone;
        }
    }
}