using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs;
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
        var listOfModels = _todoService.GetList()
            .Select(Mapper.MapDtoToModel);
        return View(listOfModels);
    }

    public IActionResult Delete(Guid id)
    {
        _todoService.Delete(id);
        return RedirectToAction("List");
    }

    public IActionResult Create(TodoViewModel todoViewModel)
    {
        _todoService.Create(Mapper.MapModelToDto(todoViewModel));
        return RedirectToAction("List");
    }

    public IActionResult UpdateView(Guid id)
    {
        var todoItem = _todoService.GetById(id);
        return View("Update", Mapper.MapDtoToModel(todoItem));
    }

    public IActionResult Update(Guid id, TodoViewModel todoViewModel)
    {
        _todoService.Update(id, Mapper.MapModelToDto(todoViewModel));
        return RedirectToAction("List");
    }
}