using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class updatedlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Output",
                table: "LogMessages",
                newName: "Parameters");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "LogMessages",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "LogMessages");

            migrationBuilder.RenameColumn(
                name: "Parameters",
                table: "LogMessages",
                newName: "Output");
        }
    }
}
