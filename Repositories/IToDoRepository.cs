using ToDo.Entities;

namespace ToDo.Repositories;

public interface IToDoRepository
{
    List<TodoItem> GetList();
    void Create(TodoItem toDoItem);
    void Update(Guid id, TodoItem toDoItem);
    void Delete(Guid id);
    TodoItem GetById(Guid id);
}