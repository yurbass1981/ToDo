using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public IActionResult List()
        {
            var filteredToDoList = _toDoService.GetList();
            return View(filteredToDoList);
        }

        public IActionResult Delete(Guid id)
        {
            _toDoService.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Create(Models.ToDoItemDto model)
        {
            _toDoService.Create(model.Text);
            return RedirectToAction("List");
        }

        public IActionResult UpdateView(Guid id)
        {
            Models.ToDoItemDto itemToUpdate = _toDoService.GetById(id);
            return View("Update", itemToUpdate);
        }

        public IActionResult Update(Guid id, ToDoViewModel model)
        {
            var toDoItem = new DTOs.ToDoItemDto()
            {
                Id = model.Id,
                Text = model.Text,
                Created = model.Created,
                IsCompleted = model.IsCompleted
            };

            _toDoService.Update(id, toDoItem);
            return RedirectToAction("List");
        }
    }
}