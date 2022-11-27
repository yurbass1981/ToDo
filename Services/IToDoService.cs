using ToDo.Models;

namespace ToDo.Services
{
    public interface IToDoService
    {
        List<ToDoViewModel> GetList();
        void Create(string text);
        void Update(int id);
        void Delete(int id);
    }
}
