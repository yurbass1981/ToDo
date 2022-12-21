using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs;
using ToDo.Models;
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
        //TODO: try to map return type (TodoItemDto to TodoViewModel)
        // there are some difficult things maybe, because we need to map not one object but a collection of objects
        // you can use foreach for it or lambda type
        var todoItemDtoList = _todoService.GetList();
        var viewModelList = new List<TodoViewModel>();

        foreach (var todoDto in todoItemDtoList)
        {
            var todoViewModel = new TodoViewModel
            {
                Id = todoDto.Id,
                Text = todoDto.Text,
                Created = todoDto.Created,
                IsCompleted = todoDto.IsCompleted
            };

            viewModelList.Add(todoViewModel);
        }
        return View(todoItemDtoList);
    }

    public IActionResult Delete(Guid id)
    {
        _todoService.Delete(id);
        return RedirectToAction("List");
    }

    public IActionResult Create(TodoViewModel todoViewModel)
    {
        var todoItemDto = new TodoItemDto()
        {
            Id = Guid.NewGuid(),
            Text = todoViewModel.Text,
            Created = DateTime.Now
        };

        _todoService.Create(todoItemDto);
        return RedirectToAction("List");
    }

    public IActionResult UpdateView(Guid id)
    {
        var todoDto = _todoService.GetById(id);

        var todoViewModel = new TodoViewModel
        {
            Id = todoDto.Id,
            Text = todoDto.Text,
            Created = todoDto.Created,
            IsCompleted = todoDto.IsCompleted
        };

        return View("Update", todoViewModel);
    }

    public IActionResult Update(Guid id, TodoViewModel todoViewModel)
    {
        var todoItemDto = new TodoItemDto()
        {
            Id = todoViewModel.Id,
            Text = todoViewModel.Text,
            Created = todoViewModel.Created,
            IsCompleted = todoViewModel.IsCompleted
        };

        _todoService.Update(id, todoItemDto);
        return RedirectToAction("List");
    }
}