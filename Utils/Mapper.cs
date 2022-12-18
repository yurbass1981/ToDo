using ToDo.DTOs;
using ToDo.Models;

namespace ToDo.Utils;

public static class Mapper
{
    public static TodoViewModel MapDtoToModel(TodoItemDto todoItem)
    {
        return new TodoViewModel
        {
            Id = todoItem.Id,
            Text = todoItem.Text,
            IsCompleted = todoItem.IsCompleted,
            Created = todoItem.Created
        };
    }

    public static TodoItemDto MapModelToDto(TodoViewModel toDoViewModel)
    {
        return new TodoItemDto()
        {
            Id = toDoViewModel.Id,
            Text = toDoViewModel.Text,
            IsCompleted = toDoViewModel.IsCompleted,
            Created = toDoViewModel.Created
        };
    }
}