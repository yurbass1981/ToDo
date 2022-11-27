using ToDo.Models;

namespace ToDo.Services
{
    public class ToDoService : IToDoService
    {
        private static List<ToDoViewModel> toDoList = new();

        public List<ToDoViewModel> GetList()
        {
            return toDoList;
        }

        public void Create(string text)
        {
            var newId = toDoList.Count == 0 ? 1 : toDoList.Max(toDoItem => toDoItem.Id) + 1;
            toDoList.Add(new ToDoViewModel()
            {
                Id = newId,
                Text = text,
                Created = DateTime.Now
            });
        }

        public void Update(int id)
        {
            ToDoViewModel toDoItemToUpdate = null;
        }

        public void Delete(int id)
        {
            ToDoViewModel toDoItemToDelete = null;

            foreach (var toDoItem in toDoList)
            {
                if (toDoItem.Id == id)
                {
                    toDoItemToDelete = toDoItem;
                    break;
                }
            }

            if (toDoItemToDelete == null)
            {
                throw new Exception("Not found");
            }

            toDoList.Remove(toDoItemToDelete);
        }

    }
}
