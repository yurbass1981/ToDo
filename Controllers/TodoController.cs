using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.DTOs;
using ToDo.Services;

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
      var viewModelList = new List<TodoViewModel>();


      //TODO: we need to learn LINQ and rewrite this part of code to LINQ expression
      foreach (var todoDto in todoItemDtoList)
      {
         var todoViewModel = MapDtoToModel(todoDto);
         viewModelList.Add(todoViewModel);
      }
      return View(viewModelList);
   }

   public IActionResult Delete(Guid id)
   {
      _todoService.Delete(id);
      return RedirectToAction("List");
   }

   public IActionResult Create(TodoViewModel todoViewModel)
   {
      var todoItemDto = MapModelToDto(todoViewModel);

      _todoService.Create(todoItemDto);
      return RedirectToAction("List");
   }

   public IActionResult UpdateView(Guid id)
   {
      var todoDto = _todoService.GetById(id);

      var todoViewModel = MapDtoToModel(todoDto);
      return View("Update", todoViewModel);
   }

   public IActionResult Update(Guid id, TodoViewModel todoViewModel)
   {
      var todoItemDto = MapModelToDto(todoViewModel);
      
      _todoService.Update(id, todoItemDto);
      return RedirectToAction("List");
   }

   private TodoViewModel MapDtoToModel(TodoItemDto todoItemDto)
   {
      return new TodoViewModel
      {
         Id = todoItemDto.Id,
         Text = todoItemDto.Text,
         IsCompleted = todoItemDto.IsCompleted
      };
   }

   private TodoItemDto MapModelToDto(TodoViewModel todoViewModel)
   {
    return new TodoItemDto
    {
         Id = todoViewModel.Id,
         Text = todoViewModel.Text,
         IsCompleted = todoViewModel.IsCompleted
    };
   }
}