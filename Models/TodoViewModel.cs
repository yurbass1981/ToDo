namespace ToDo.Models;

public class TodoViewModel
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Created { get; set; }
}