using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Services;
using ToDo.Utils;

namespace ToDo.Controllers;

public class TodoController : Controller
{
   private readonly ITodoService _todoService;

   public TodoController(ITodoService todoService)
   {
      _todoService = todoService;
   }

   public IActionResult List()
   {
      var todoItemList = _todoService.GetList();
      var viewModelList = todoItemList.Select(Mapper.MapEntityToModel);
     
      return View(viewModelList);
   }

   public IActionResult Delete(Guid id)
   {
      _todoService.Delete(id);
      return RedirectToAction("List");
   }

   public IActionResult Create(TodoViewModel todoViewModel)
   {
      var todoItem = Mapper.MapModelToEntity(todoViewModel);

      _todoService.Create(todoItem);
      return RedirectToAction("List");
   }

   public IActionResult UpdateView(Guid id)
   {
      var todoItem = _todoService.GetById(id);

      var todoViewModel = Mapper.MapEntityToModel(todoItem);
      return View("Update", todoViewModel);
   }

   public IActionResult Update(Guid id, TodoViewModel todoViewModel)
   {
      var todoItem = Mapper.MapModelToEntity(todoViewModel);
      
      _todoService.Update(id, todoItem);
      return RedirectToAction("List");
   }
}