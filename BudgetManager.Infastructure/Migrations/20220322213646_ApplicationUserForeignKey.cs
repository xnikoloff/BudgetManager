using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class ApplicationUserForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Incomes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "AppicationUserId",
                table: "Incomes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppicationUserId",
                table: "Expenses",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
