﻿using ToDo.DAL.Entities;

namespace ToDo.Repositories;

public interface ITodoRepository
{
    List<TodoItem> GetList();
    void Create(TodoItem toDoItem);
    void Update(Guid id, TodoItem toDoItem);
    void Delete(Guid id);
    TodoItem GetById(Guid id);
}