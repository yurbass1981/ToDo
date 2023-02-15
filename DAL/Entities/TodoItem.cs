namespace ToDo.DAL.Entities;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsDone { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}