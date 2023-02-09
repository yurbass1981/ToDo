using Microsoft.EntityFrameworkCore;
using ToDo.DBL.Entities;
using ToDo.DBL.EntityConfiguration;

namespace ToDo.DBL;

public class AppDBContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new TodoItemEntityTypeConfiguration().Configure(modelBuilder.Entity<TodoItem>());
    }
}