using ToDo.Models;
using ToDo.Repositories;

namespace ToDo.Services.Implemention
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }



        public List<ToDoViewModel> GetList()
        {
            return toDoRepository.GetList();
        }

        public void Create(string text)
        {
            var newToDoItem = new ToDoViewModel()
            {
                Text = text,
                Created = DateTime.Now
            };

            toDoRepository.Create(newToDoItem);
        }

        public void Update(ToDoViewModel toDoItem)
        {
            toDoRepository.Update(toDoItem);
        }

        public void Delete(int id)
        {
            toDoRepository.Delete(id);
        }

        public ToDoViewModel GetById(int id)
        {
            ToDoViewModel itemById = toDoRepository.GetById(id);

            if (itemById != null)
            {
                return itemById;
            }
            
                throw new Exception($"Todo item with id {id} hasn't been found");
            
        }
    }
}
