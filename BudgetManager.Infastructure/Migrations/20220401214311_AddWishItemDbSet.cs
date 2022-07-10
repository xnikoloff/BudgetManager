using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManager.Infastructure.Migrations
{
    public partial class AddWishItemDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishItem_AspNetUsers_ApplicationUserId",
                table: "WishItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishItem",
                table: "WishItem");

            migrationBuilder.RenameTable(
                name: "WishItem",
                newName: "WishItems");

            migrationBuilder.RenameIndex(
                name: "IX_WishItem_ApplicationUserId",
                table: "WishItems",
                newName: "IX_WishItems_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishItems",
                table: "WishItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishItems_AspNetUsers_ApplicationUserId",
                table: "WishItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishItems_AspNetUsers_ApplicationUserId",
                table: "WishItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishItems",
                table: "WishItems");

            migrationBuilder.RenameTable(
                name: "WishItems",
                newName: "WishItem");

            migrationBuilder.RenameIndex(
                name: "IX_WishItems_ApplicationUserId",
                table: "WishItem",
                newName: "IX_WishItem_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishItem",
                table: "WishItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishItem_AspNetUsers_ApplicationUserId",
                table: "WishItem",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
