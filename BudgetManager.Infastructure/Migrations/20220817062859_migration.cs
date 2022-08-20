using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseGroup_ExpenseGroupId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseGroup",
                table: "ExpenseGroup");

            migrationBuilder.RenameTable(
                name: "ExpenseGroup",
                newName: "ExpenseGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseGroups",
                table: "ExpenseGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseGroups_ExpenseGroupId",
                table: "Expenses",
                column: "ExpenseGroupId",
                principalTable: "ExpenseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseGroups_ExpenseGroupId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseGroups",
                table: "ExpenseGroups");

            migrationBuilder.RenameTable(
                name: "ExpenseGroups",
                newName: "ExpenseGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseGroup",
                table: "ExpenseGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseGroup_ExpenseGroupId",
                table: "Expenses",
                column: "ExpenseGroupId",
                principalTable: "ExpenseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
