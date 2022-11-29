using ToDo.Models;

namespace ToDo.Repositories
{
    public interface IToDoRepository
    {
        List<ToDoViewModel> GetList();
        void Create(string text);
        void Update(ToDoViewModel toDoItem);
        void Delete(int id);
    }
}
