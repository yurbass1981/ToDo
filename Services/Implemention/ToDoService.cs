﻿using ToDo.Models;
using ToDo.Repositories;

namespace ToDo.Services.Implemention
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }



        public List<ToDoViewModel> GetList()
        {
            return toDoRepository.GetList();
        }

        public void Create(string text)
        {
            var newToDoItem = new ToDoViewModel()
            {
                Id = Guid.NewGuid(),
                Text = text,
                Created = DateTime.Now
            };

            toDoRepository.Create(newToDoItem);
        }

        public void Update(Guid id, ToDoViewModel toDoItem)
        {
            toDoRepository.Update(id, toDoItem);
        }

        public void Delete(Guid id)
        {
            toDoRepository.Delete(id);
        }

        public ToDoViewModel GetById(Guid id)
        {
            var itemById = toDoRepository.GetById(id);

            if (itemById == null)
            {
                throw new Exception($"Todo item with id {id} hasn't been found");
            }

            return itemById;

        }
    }
}
