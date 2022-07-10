using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class AddIsOwnedPropToWithItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOwned",
                table: "WishItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwned",
                table: "WishItems");
        }
    }
}
