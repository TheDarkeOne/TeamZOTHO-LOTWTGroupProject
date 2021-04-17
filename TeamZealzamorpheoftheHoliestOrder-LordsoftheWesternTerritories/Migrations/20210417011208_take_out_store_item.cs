using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class take_out_store_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_StoreItems_ItemId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ItemId",
                table: "CartItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_StoreItems_ItemId",
                table: "CartItems",
                column: "ItemId",
                principalTable: "StoreItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
