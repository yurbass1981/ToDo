using ToDo.DBL.Entities;
using ToDo.Repositories;

namespace ToDo.Services.Implementation;

public class TodoService : ITodoService
{
   private readonly IToDoRepository _toDoRepository;
   private readonly ILogger<TodoService> _logger;

   public TodoService(ILogger<TodoService> logger, IToDoRepository toDoRepository)
   {
      _toDoRepository = toDoRepository;
      _logger = logger;
   }


   public List<TodoItem> GetList()
   {
      _logger.LogInformation($"Executing {nameof(GetList)} method");
      return _toDoRepository.GetList();
   }

   public void Create(TodoItem todoItem)
   {
      _logger.LogInformation($"Executing {nameof(Create)} method");
      todoItem.Id = Guid.NewGuid();
      todoItem.Created = DateTime.Now;
      _toDoRepository.Create(todoItem);
   }

   public void Update(Guid id, TodoItem todoItem)
   {
      _logger.LogInformation($"Executing {nameof(Update)} method. Trying to update todoItem with id: {id}");
      todoItem.Updated = DateTime.Now;
      _toDoRepository.Update(id, todoItem);
   }

   public void Delete(Guid id)
   {
      _logger.LogInformation($"Executing {nameof(Delete)} method. Trying to delete todoItem with id: {id}");
      _toDoRepository.Delete(id);
   }

   public TodoItem GetById(Guid id)
   {
      _logger.LogInformation($"Executing {nameof(GetById)} method. Trying to get todoItem with id: {id}");
      var itemById = _toDoRepository.GetById(id);

      if (itemById == null)
      {
         var ex = new Exception($"Todo item with id {id} hasn't been found");
         _logger.LogError(ex.Message);
         throw ex;
      }

      return itemById;
   }
}