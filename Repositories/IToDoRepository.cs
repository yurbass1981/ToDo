using ToDo.DTOs;

namespace ToDo.Repositories;

public interface IToDoRepository
{
    List<TodoItemDto> GetList();
    void Create(TodoItemDto toDoItem);
    void Update(Guid id, TodoItemDto toDoItem);
    void Delete(Guid id);
    TodoItemDto? GetById(Guid id);
}