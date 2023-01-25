using ToDo.DBL.Entities;
using ToDo.Utils;

namespace ToDo.Repositories.Implementation
{
    public class InJsonFileToDoRepository : IToDoRepository
    {
        private readonly string _filePath;

        public InJsonFileToDoRepository(IConfiguration config)
        {
            _filePath = config.GetSection("StorageFilePath").Value;
            if (string.IsNullOrEmpty(_filePath))
            {
                throw new Exception("FilePath hasn't been found");
            }
        }


        public void Create(TodoItem toDoItem)
        {
            List<TodoItem> todoItemList = JsonParser<List<TodoItem>>.Read(_filePath);
            todoItemList.Add(toDoItem);
            JsonParser<List<TodoItem>>.Write(_filePath, todoItemList);
        }


        public void Delete(Guid id)
        {
            List<TodoItem> todoItemList = JsonParser<List<TodoItem>>.Read(_filePath);

            var todoItemToRemove = todoItemList.FirstOrDefault(item => item.Id == id);
            if (todoItemToRemove == null)
            {
                throw new Exception($"todoItemToRemove whith id {id} hasn't been found");
            }

            todoItemList.Remove(todoItemToRemove);

            JsonParser<List<TodoItem>>.Write(_filePath, todoItemList);
        }


        public TodoItem GetById(Guid id)
        {
            return JsonParser<List<TodoItem>>.Read(_filePath).First(i => i.Id == id);
        }


        public List<TodoItem> GetList()
        {
            if (!File.Exists(_filePath))
            {
                var fs = File.Create(_filePath);
                fs.Close();
                JsonParser<List<TodoItem>>.Write(_filePath, new List<TodoItem>());
            }

            return JsonParser<List<TodoItem>>.Read(_filePath);
        }


        public void Update(Guid id, TodoItem toDoItem)
        {
            List<TodoItem> todoItemList = JsonParser<List<TodoItem>>.Read(_filePath)
                .Select(item =>
                {
                    if (item.Id == id)
                    {
                        item.Created = toDoItem.Created;
                        item.IsCompleted = toDoItem.IsCompleted;
                        item.Text = toDoItem.Text;
                        item.Updated = DateTime.Now;
                    }

                    return item;
                })
                .ToList();

            JsonParser<List<TodoItem>>.Write(_filePath, todoItemList);
        }
    }
}