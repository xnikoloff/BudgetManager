using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class AddExpenseGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseGroupId",
                table: "Expenses",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExpenseGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseGroupId",
                table: "Expenses",
                column: "ExpenseGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseGroup_ExpenseGroupId",
                table: "Expenses",
                column: "ExpenseGroupId",
                principalTable: "ExpenseGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseGroup_ExpenseGroupId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseGroup");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseGroupId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseGroupId",
                table: "Expenses");
        }
    }
}
