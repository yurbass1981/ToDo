using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.DTOs;
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
      var todoItemDtoList = _todoService.GetList();
      var viewModelList = todoItemDtoList.Select(todoDto => Mapper.MapDtoToModel(todoDto));
     
      return View(viewModelList);
   }

   public IActionResult Delete(Guid id)
   {
      _todoService.Delete(id);
      return RedirectToAction("List");
   }

   public IActionResult Create(TodoViewModel todoViewModel)
   {
      var todoItemDto = Mapper.MapModelToDto(todoViewModel);

      _todoService.Create(todoItemDto);
      return RedirectToAction("List");
   }

   public IActionResult UpdateView(Guid id)
   {
      var todoDto = _todoService.GetById(id);

      var todoViewModel = Mapper.MapDtoToModel(todoDto);
      return View("Update", todoViewModel);
   }

   public IActionResult Update(Guid id, TodoViewModel todoViewModel)
   {
      var todoItemDto = Mapper.MapModelToDto(todoViewModel);
      
      _todoService.Update(id, todoItemDto);
      return RedirectToAction("List");
   }
}