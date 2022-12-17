using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoService
    {
        List<ToDoViewModel> GetList();
        void Create(string text);
        void Update(Guid id, ToDoViewModel toDoItem);
        void Delete(Guid id);
        ToDoViewModel GetById(Guid id);
    }
}
