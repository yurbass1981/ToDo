using ToDo.DBL;
using ToDo.DBL.Entities;

namespace ToDo.Repositories.Implementation
{
    public class InDbTodoRepository : IToDoRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<InDbTodoRepository> _logger;

        public InDbTodoRepository(ILogger<InDbTodoRepository> logger, AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Create(TodoItem toDoItem)
        {
            _logger.LogInformation($"Executing {nameof(Create)} method");
            _dbContext.TodoItems.Add(toDoItem);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var todoItemToDelete = GetById(id);
            _logger.LogInformation($"Executing {nameof(Delete)} method. Trying to delete todoItem with id: {id}");
            _dbContext.TodoItems.Remove(todoItemToDelete);
            _dbContext.SaveChanges();
        }

        public TodoItem GetById(Guid id)
        {
            _logger.LogInformation($"Executing {nameof(GetById)} method. Trying to get todoItem with id: {id}");
            var todoItemById = _dbContext.TodoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemById == null)
            {
                var ex = new Exception($"Todo item with id {id} hasn't been found");
                _logger.LogError(ex.Message);
                throw ex;
            }

            return todoItemById;
        }

        public List<TodoItem> GetList()
        {
            _logger.LogInformation($"Executing {nameof(GetList)} method");
            return _dbContext.TodoItems.ToList();
        }

        public void Update(Guid id, TodoItem toDoItem)
        {
            _logger.LogInformation($"Executing {nameof(Update)} method. Trying to update todoItem with id: {id}");
            var todoItemById = GetById(id);
            todoItemById.Text = toDoItem.Text;
            todoItemById.IsDone = toDoItem.IsDone;
            todoItemById.Updated = toDoItem.Updated;

            _dbContext.SaveChanges();
        }
    }
}