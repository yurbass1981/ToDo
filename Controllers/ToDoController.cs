using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult Create(string text)
        {
            _toDoService.Create(text);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            _toDoService.Update(id);
            return View();
        }
    }
}