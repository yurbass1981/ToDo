using ToDo.DTOs;

namespace ToDo.Repositories.Implementation;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<TodoItemDto> _todoStorage = new();

    public void Create(TodoItemDto toDoItem)
    {
        _todoStorage.Add(toDoItem);
    }

    public void Delete(Guid id)
    {
        TodoItemDto toDoItemToDelete = _todoStorage.FirstOrDefault(item => item.Id == id);
        if (toDoItemToDelete == null)
        {
            throw new Exception($"toDoItemToDelete whith id {id} hasn't been found");
        }

        // TodoItemDto toDoItemToDelete = null;
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

    public TodoItemDto GetById(Guid id)
    {
        return _todoStorage.FirstOrDefault(ti => ti.Id == id);
    }

    public List<TodoItemDto> GetList()
    {
        //TODO: Replase by foreach
        return _todoStorage.OrderByDescending(ti => ti.Created).ToList();
    }

    public void Update(Guid id, TodoItemDto toDoItem)
    {
        var itemToUpdate = GetById(id);

        if (itemToUpdate != null)
        {
            itemToUpdate.Text = toDoItem.Text;
            itemToUpdate.IsCompleted = toDoItem.IsCompleted;
        }
    }
}