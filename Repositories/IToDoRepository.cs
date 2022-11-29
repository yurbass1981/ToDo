using ToDo.Models;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoViewModel> GetList();
        void Create(ToDoViewModel toToItem);
        void Update(ToDoViewModel toDoItem);
        void Delete(int id);
    }

}
