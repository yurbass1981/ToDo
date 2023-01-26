using ToDo.DBL.Entities;
using ToDo.Models;

namespace ToDo.Utils;

public static class Mapper
{
    public static TodoViewModel MapEntityToModel(TodoItem todoItem)
    {
        return new TodoViewModel
        {
            Id = todoItem.Id,
            Text = todoItem.Text,
            IsCompleted = todoItem.IsCompleted
        };
    }

    public static TodoItem MapModelToEntity(TodoViewModel toDoViewModel)
    {
        return new TodoItem()
        {
            Id = toDoViewModel.Id,
            Text = toDoViewModel.Text,
            IsCompleted = toDoViewModel.IsCompleted
        };
    }
}