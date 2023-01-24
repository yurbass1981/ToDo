using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Entities;

namespace ToDo.DBL.EntityConfiguration;

public class TodoItemEntityTypeConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {

        builder.Property(nameof(TodoItem.Text))
            .HasMaxLength(1000)
            .IsRequired();
        
        builder.Property(nameof(TodoItem.Created))
            .IsRequired();


        // builder.Property(nameof(Employee.Name))
        //     .HasMaxLength(50)
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.Surname))
        //     .HasMaxLength(50)
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.Birthday))
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.HiringDate))
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.Position))
        //     .HasMaxLength(100)
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.Department))
        //     .HasMaxLength(100)
        //     .IsRequired();
        //
        // builder.Property(nameof(Employee.IsActive))
        //     .HasDefaultValue(false);
        //
        // builder
        //     .HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));
    }
}