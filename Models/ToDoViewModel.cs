namespace ToDo.Models
{
    public class ToDoViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Created { get; set; }
    }
}
