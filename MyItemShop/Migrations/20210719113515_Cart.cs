using Microsoft.EntityFrameworkCore.Migrations;

namespace MyItemShop.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cart",
                table: "Users",
                type: "varchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cart",
                table: "Users");
        }
    }
}
