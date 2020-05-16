using Microsoft.EntityFrameworkCore.Migrations;

namespace WastelessAPI.DataAccess.Migrations
{
    public partial class Waste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotifyWaste",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "notify_expiration",
                table: "grocery_items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifyWaste",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "notify_expiration",
                table: "grocery_items");
        }
    }
}
