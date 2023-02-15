using ToDo.DBL.Entities;
using ToDo.Repositories;

namespace ToDo.Services.Implementation;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly ILogger<TodoService> _logger;

    public TodoService(ILogger<TodoService> logger, ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
        _logger = logger;
    }


    public List<TodoItem> GetList()
    {
        _logger.LogInformation($"Executing {nameof(GetList)} method");
        return _todoRepository.GetList();
    }

    public void Create(TodoItem todoItem)
    {
        _logger.LogInformation($"Executing {nameof(Create)} method");
        todoItem.Id = Guid.NewGuid();
        todoItem.Created = DateTime.Now;
        _todoRepository.Create(todoItem);
    }

    public void Update(Guid id, TodoItem todoItem)
    {
        _logger.LogInformation($"Executing {nameof(Update)} method. Trying to update todoItem with id: {id}");
        todoItem.Updated = DateTime.Now;
        _todoRepository.Update(id, todoItem);
    }

    public void Delete(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(Delete)} method. Trying to delete todoItem with id: {id}");
        _todoRepository.Delete(id);
    }

    public TodoItem GetById(Guid id)
    {
        _logger.LogInformation($"Executing {nameof(GetById)} method. Trying to get todoItem with id: {id}");
        var itemById = _todoRepository.GetById(id);

        if (itemById == null)
        {
            var ex = new Exception($"Todo item with id {id} hasn't been found");
            _logger.LogError(ex.Message);
            throw ex;
        }

        return itemById;
    }
}