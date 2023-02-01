using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.DBL.Migrations
{
    /// <inheritdoc />
    public partial class RenamedColumnFromIsCompletedToIsDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "TodoItems",
                newName: "IsDone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "TodoItems",
                newName: "IsCompleted");
        }
    }
}
