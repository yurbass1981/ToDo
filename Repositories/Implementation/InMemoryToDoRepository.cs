using ToDo.Entities;

namespace ToDo.Repositories.Implementation;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<TodoItem> _todoStorage = new();

    public void Create(TodoItem toDoItem)
    {
        _todoStorage.Add(toDoItem);
    }

    public void Delete(Guid id)
    {
        TodoItem toDoItemToDelete = _todoStorage.FirstOrDefault(item => item.Id == id);
        if (toDoItemToDelete == null)
        {
            throw new Exception($"toDoItemToDelete whith id {id} hasn't been found");
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
        return _todoStorage.FirstOrDefault(ti => ti.Id == id);
    }

    public List<TodoItem> GetList()
    {
        //TODO: Replase by foreach
        return _todoStorage.OrderByDescending(ti => ti.Created).ToList();
    }

    public void Update(Guid id, TodoItem toDoItem)
    {
        var itemToUpdate = GetById(id);

        if (itemToUpdate != null)
        {
            itemToUpdate.Text = toDoItem.Text;
            itemToUpdate.IsCompleted = toDoItem.IsCompleted;
        }
    }
}