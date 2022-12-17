using ToDo.DTOs;

namespace ToDo.Services;

public interface ITodoService
{
    List<TodoItemDto> GetList();
    void Create(TodoItemDto todoItem);
    void Update(Guid id, TodoItemDto todoItem);
    void Delete(Guid id);
    TodoItemDto GetById(Guid id);
}