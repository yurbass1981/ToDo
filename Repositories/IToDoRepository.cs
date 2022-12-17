using ToDo.Models;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoViewModel> GetList();
        void Create(ToDoViewModel toDoItem);
        void Update(Guid id, ToDoViewModel toDoItem);
        void Delete(Guid id);       
        ToDoViewModel? GetById(Guid id);
    }

}
