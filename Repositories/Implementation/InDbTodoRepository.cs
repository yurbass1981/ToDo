using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.DBL;
using ToDo.DBL.Entities;

namespace ToDo.Repositories.Implementation
{
    public class InDbTodoRepository : IToDoRepository
    {
        private readonly ApplicationContext _dbContext;

        public InDbTodoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(TodoItem toDoItem)
        {
            _dbContext.TodoItems.Add(toDoItem);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var todoItemToDelete = GetById(id);
            _dbContext.TodoItems.Remove(todoItemToDelete);
            _dbContext.SaveChanges();
        }

        public TodoItem GetById(Guid id)
        {
            var todoItemById = _dbContext.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemById == null)
                throw new Exception($"todoItemById whith id {id} hasn't been found");

            return todoItemById;
        }

        public List<TodoItem> GetList()
        {
            return _dbContext.TodoItems.ToList();
        }

        public void Update(Guid id, TodoItem toDoItem)
        {
            var todoItemById = GetById(id);
            todoItemById.Text = toDoItem.Text;
            todoItemById.IsCompleted = toDoItem.IsCompleted;
            todoItemById.Updated = toDoItem.Updated;

            _dbContext.SaveChanges();
        }
    }
}