using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppicationUserId",
                table: "Incomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppicationUserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_AppicationUserId",
                table: "Incomes",
                column: "AppicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_AppicationUserId",
                table: "Expenses",
                column: "AppicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_AppicationUserId",
                table: "Expenses",
                column: "AppicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_AppicationUserId",
                table: "Incomes",
                column: "AppicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_AppicationUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_AppicationUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_AppicationUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_AppicationUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "AppicationUserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "AppicationUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
