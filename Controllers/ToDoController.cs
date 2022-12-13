using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Delete(int id)
        {
            _toDoService.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Create(ToDoViewModel toDoItem)
        {
            _toDoService.Create(toDoItem.Text);
            return RedirectToAction("List");
        }

        public IActionResult UpdateView(int id)
        {
            ToDoViewModel itemToUpdate = _toDoService.GetById(id);
            return View("Update", itemToUpdate);
        }

        public IActionResult Update(int id, ToDoViewModel toDoItem)
        {
            _toDoService.Update(id, toDoItem);
            return RedirectToAction("List");
        }
    }
}