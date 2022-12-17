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
        var filteredToDoList = _todoService.GetList();
        return View(filteredToDoList);
    }

    public IActionResult Delete(Guid id)
    {
        _todoService.Delete(id);
        return RedirectToAction("List");
    }

    public IActionResult Create(TodoViewModel todoViewModel)
    {
        //TODO: model has to be mapped
        _todoService.Create(todoViewModel);
        return RedirectToAction("List");
    }

    public IActionResult UpdateView(Guid id)
    {
        //TODO: model has to be mapped
        TodoViewModel itemToUpdate = _todoService.GetById(id);
        return View("Update", itemToUpdate);
    }

    public IActionResult Update(Guid id, TodoViewModel todoItem)
    {
        //TODO: model has to be mapped
        _todoService.Update(id, todoItem);
        return RedirectToAction("List");
    }
}