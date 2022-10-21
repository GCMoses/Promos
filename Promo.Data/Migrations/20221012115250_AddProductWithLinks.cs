using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Promo.Data.Migrations
{
    public partial class AddProductWithLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Products");
        }
    }
}
