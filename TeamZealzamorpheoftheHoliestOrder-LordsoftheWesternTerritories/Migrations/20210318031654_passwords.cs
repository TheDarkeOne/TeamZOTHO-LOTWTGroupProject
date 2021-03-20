using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class passwords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }
    }
}
