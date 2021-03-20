using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class saltier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SessionKey",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SessionKey",
                table: "Users");
        }
    }
}
