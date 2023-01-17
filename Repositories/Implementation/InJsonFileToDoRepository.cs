using ToDo.DTOs;
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


        public void Create(TodoItemDto toDoItem)
        {
            List<TodoItemDto> todoItemList = JsonParser<List<TodoItemDto>>.Read(_filePath);
            todoItemList.Add(toDoItem);
            JsonParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
        }


        public void Delete(Guid id)
        {
            List<TodoItemDto> todoItemList = JsonParser<List<TodoItemDto>>.Read(_filePath);

            var todoItemToRemove = todoItemList.FirstOrDefault(item => item.Id == id);
            if (todoItemToRemove == null)
            {
                throw new Exception($"todoItemToRemove whith id {id} hasn't been found");
            }

            todoItemList.Remove(todoItemToRemove);

            JsonParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
        }


        public TodoItemDto GetById(Guid id)
        {
            return JsonParser<List<TodoItemDto>>.Read(_filePath).First(i => i.Id == id);
        }


        public List<TodoItemDto> GetList()
        {
            if (!File.Exists(_filePath))
            {
                var fs = File.Create(_filePath);
                fs.Close();
                JsonParser<List<TodoItemDto>>.Write(_filePath, new List<TodoItemDto>());
            }

            return JsonParser<List<TodoItemDto>>.Read(_filePath);
        }


        public void Update(Guid id, TodoItemDto toDoItem)
        {
            List<TodoItemDto> todoItemList = JsonParser<List<TodoItemDto>>.Read(_filePath);

            foreach (var item in todoItemList)
            {
                if (item.Id == id)
                {
                    item.Created = toDoItem.Created;
                    item.IsCompleted = toDoItem.IsCompleted;
                    item.Text = toDoItem.Text;
                    item.Updated = DateTime.Now;
                }
            }

            JsonParser<List<TodoItemDto>>.Write(_filePath, todoItemList);
        }
    }
}