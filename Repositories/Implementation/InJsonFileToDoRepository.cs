using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.DTOs;

namespace ToDo.Repositories.Implementation
{
    public class InJsonFileToDoRepository : IToDoRepository
    {
        private readonly string _filePath;
        public void Create(TodoItemDto toDoItem)
        {
            List<TodoItemDto> todoItemList = JsonParse<List<TodoItemDto>>.Read(_filePath);


            // throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TodoItemDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TodoItemDto> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, TodoItemDto toDoItem)
        {
            throw new NotImplementedException();
        }
    }
}