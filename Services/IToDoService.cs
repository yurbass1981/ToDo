using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoService
    {
        List<ToDoViewModel> GetList();
        void Create(string text);
        void Update(int id, ToDoViewModel toDoItem);
        void Delete(int id);
        ToDoViewModel GetById(int id);
    }
}
