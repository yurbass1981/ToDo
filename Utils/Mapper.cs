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
            IsDone = todoItem.IsDone
        };
    }

    public static TodoItem MapModelToEntity(TodoViewModel todoViewModel)
    {
        return new TodoItem()
        {
            Id = todoViewModel.Id,
            Text = todoViewModel.Text,
            IsDone = todoViewModel.IsDone
        };
    }
}