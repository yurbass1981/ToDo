using ToDo.Entities;

namespace ToDo.Services;

public interface ITodoService
{
    List<TodoItem> GetList();
    void Create(TodoItem todoItem);
    void Update(Guid id, TodoItem todoItem);
    void Delete(Guid id);
    TodoItem GetById(Guid id);
}