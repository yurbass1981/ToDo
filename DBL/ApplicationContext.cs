using Microsoft.EntityFrameworkCore;
using ToDo.DBL.Entities;
using ToDo.DBL.EntityConfiguration;

namespace ToDo.DBL;

public class ApplicationContext : DbContext
{

    public DbSet<TodoItem> TodoItems { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    // public ApplicationContext()
    // {
        
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new TodoItemEntityTypeConfiguration().Configure(modelBuilder.Entity<TodoItem>());
    }
}