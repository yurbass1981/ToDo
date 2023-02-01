namespace ToDo.Models;

public class TodoViewModel
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsDone { get; set; }
}