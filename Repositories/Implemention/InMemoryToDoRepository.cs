using ToDo.Models;

namespace ToDo.Repositories.Implemention
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private int lastId = 1;
        private List<ToDoViewModel> toDoStorage = new();

        public void Create(ToDoViewModel toDoItem)
        {
            toDoItem.Id = lastId;
            toDoStorage.Add(toDoItem);
            lastId++;
        }

        public void Delete(int id)
        {
            ToDoViewModel toDoItemToDelete = null;

            foreach(var item in toDoStorage)
            {
                if(item.Id == id)
                {
                    toDoItemToDelete = item;
                    break;
                }
            }

            toDoStorage.Remove(toDoItemToDelete);
        }

        public List<ToDoViewModel> GetList()
        {
            return toDoStorage;
        }

        public void Update(ToDoViewModel toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}
