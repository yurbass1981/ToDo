using ToDo.Models;

namespace ToDo.Repositories.Implemention
{
    public class InMemoryToDoRepository : IToDoRepository
    {
        private List<ToDoItemDto> toDoStorage = new();

        public void Create(ToDoItemDto toDoItem)
        {
            toDoStorage.Add(toDoItem);
        }

        public void Delete(Guid id)
        {
            ToDoItemDto toDoItemToDelete = null;

            foreach (var item in toDoStorage)
            {
                if (item.Id == id)
                {
                    toDoItemToDelete = item;
                    break;
                }
            }

            toDoStorage.Remove(toDoItemToDelete);
        }

        public ToDoItemDto? GetById(Guid id)
        {
            //foreach (var item in toDoStorage)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }
            //}

            //return null;
         
            return toDoStorage.FirstOrDefault(x=>x.Id == id);
        }

        public List<ToDoItemDto> GetList()
        {
            return toDoStorage;
        }

        public void Update(Guid id, ToDoItemDto toDoItem)
        {
            var itemToUpdate = GetById(id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Text = toDoItem.Text;
                itemToUpdate.IsCompleted = toDoItem.IsCompleted;
            }
        }
    }
}
