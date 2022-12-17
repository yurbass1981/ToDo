using ToDo.DTOs;

namespace ToDo.Repositories.Implementation;

public class InFileToDoRepository : IToDoRepository
{
    public void Create(TodoItemDto toDoItem)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public TodoItemDto GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<TodoItemDto> GetList()
    {
        throw new NotImplementedException();
    }

    public void Update(Guid id, TodoItemDto toDoItem)
    {
        throw new NotImplementedException();
    }
}