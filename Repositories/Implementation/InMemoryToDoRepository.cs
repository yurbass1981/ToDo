﻿using ToDo.DTOs;

namespace ToDo.Repositories.Implementation;

public class InMemoryToDoRepository : IToDoRepository
{
    private readonly List<TodoItemDto> _todoStorage = new();

    public void Create(TodoItemDto toDoItem)
    {
        _todoStorage.Add(toDoItem);
    }

    public void Delete(Guid id)
    {
        TodoItemDto toDoItemToDelete = null;

        foreach (var item in _todoStorage)
        {
            if (item.Id == id)
            {
                toDoItemToDelete = item;
                break;
            }
        }

        _todoStorage.Remove(toDoItemToDelete);
    }

    public TodoItemDto? GetById(Guid id)
    {
        return _todoStorage.FirstOrDefault(x => x.Id == id);
    }

    public List<TodoItemDto> GetList()
    {
        return _todoStorage;
    }

    public void Update(Guid id, TodoItemDto toDoItem)
    {
        var itemToUpdate = GetById(id);

        if (itemToUpdate != null)
        {
            itemToUpdate.Text = toDoItem.Text;
            itemToUpdate.IsCompleted = toDoItem.IsCompleted;
        }
    }
}