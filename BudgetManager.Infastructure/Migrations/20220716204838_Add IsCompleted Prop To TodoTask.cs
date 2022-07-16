using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class AddIsCompletedPropToTodoTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Todos_TodoId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "TodoTasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TodoTasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Todos_TodoId",
                table: "TodoTasks",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_Todos_TodoId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_Todos_TodoId",
                table: "TodoTasks",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
