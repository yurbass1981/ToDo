using Microsoft.EntityFrameworkCore;
using ToDo.DAL.Entities;
using ToDo.DAL.EntityConfiguration;

namespace ToDo.DAL;

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