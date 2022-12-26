using ToDo.DTOs;
using ToDo.Repositories;

namespace ToDo.Services.Implementation;

public class TodoService : ITodoService
{
   private readonly IToDoRepository _toDoRepository;

   public TodoService(IToDoRepository toDoRepository)
   {
      _toDoRepository = toDoRepository;
   }


   public List<TodoItemDto> GetList()
   {
      return _toDoRepository.GetList();
   }

   public void Create(TodoItemDto todoItem)
   {
      todoItem.Id = Guid.NewGuid();
      todoItem.Created = DateTime.Now;
      _toDoRepository.Create(todoItem);
   }

   public void Update(Guid id, TodoItemDto todoItem)
   {
      todoItem.Updated = DateTime.Now;
      _toDoRepository.Update(id, todoItem);
   }

   public void Delete(Guid id)
   {
      _toDoRepository.Delete(id);
   }

   public TodoItemDto GetById(Guid id)
   {
      var itemById = _toDoRepository.GetById(id);

      if (itemById == null)
      {
         throw new Exception($"Todo item with id {id} hasn't been found");
      }

      return itemById;
   }
}