using Microsoft.EntityFrameworkCore.Migrations;

namespace MyItemShop.Migrations
{
    public partial class order_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartUserID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "CartUserID",
                table: "CartItem",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartUserID",
                table: "CartItem",
                newName: "IX_CartItem_CartID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Cart",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_ID",
                table: "Cart",
                column: "ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartID",
                table: "CartItem",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_ID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "CartItem",
                newName: "CartUserID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_CartID",
                table: "CartItem",
                newName: "IX_CartItem_CartUserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Cart",
                newName: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserID",
                table: "Cart",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartUserID",
                table: "CartItem",
                column: "CartUserID",
                principalTable: "Cart",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
