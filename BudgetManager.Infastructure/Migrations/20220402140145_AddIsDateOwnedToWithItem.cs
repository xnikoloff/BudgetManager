using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class AddIsDateOwnedToWithItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOwned",
                table: "WishItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOwned",
                table: "WishItems");
        }
    }
}
