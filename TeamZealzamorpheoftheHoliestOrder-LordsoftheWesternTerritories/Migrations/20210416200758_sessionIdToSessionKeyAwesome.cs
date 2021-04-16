using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class sessionIdToSessionKeyAwesome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "CartItems",
                newName: "SessionKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionKey",
                table: "CartItems",
                newName: "SessionId");
        }
    }
}
