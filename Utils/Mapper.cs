using ToDo.DAL.Entities;
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
            IsDone = todoItem.IsDone
        };
    }

    public static TodoItem MapModelToEntity(TodoViewModel toDoViewModel)
    {
        return new TodoItem()
        {
            Id = toDoViewModel.Id,
            Text = toDoViewModel.Text,
            IsDone = toDoViewModel.IsDone
        };
    }
}