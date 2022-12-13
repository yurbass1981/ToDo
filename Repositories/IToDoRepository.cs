using ToDo.Models;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoViewModel> GetList();
        void Create(ToDoViewModel toDoItem);
        void Update(int id, ToDoViewModel toDoItem);
        void Delete(int id);
        ToDoViewModel? GetById(int id);
    }

}
