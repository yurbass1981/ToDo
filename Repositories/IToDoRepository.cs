using ToDo.Models;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoItemDto> GetList();
        void Create(ToDoItemDto toDoItem);
        void Update(Guid id, ToDoItemDto toDoItem);
        void Delete(Guid id);       
        ToDoItemDto? GetById(Guid id);
    }

}
