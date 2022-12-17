using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoService
    {
        List<ToDoItemDto> GetList();
        void Create(string text);
        void Update(Guid id, ToDoItemDto toDoItem);
        void Delete(Guid id);
        ToDoItemDto GetById(Guid id);
    }
}
