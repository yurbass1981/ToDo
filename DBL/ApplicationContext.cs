using Microsoft.EntityFrameworkCore;
using ToDo.DBL.EntityConfiguration;
using ToDo.Entities;

namespace ToDo.DBL;

public class ApplicationContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new TodoItemEntityTypeConfiguration()
            .Configure(modelBuilder.Entity<TodoItem>());
    }
}