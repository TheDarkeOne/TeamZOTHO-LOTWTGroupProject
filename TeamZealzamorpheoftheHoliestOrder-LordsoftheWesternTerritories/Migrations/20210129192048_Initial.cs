using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryStoreItem",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    StoreItemsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryStoreItem", x => new { x.CategoriesId, x.StoreItemsId });
                    table.ForeignKey(
                        name: "FK_CategoryStoreItem_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryStoreItem_StoreItems_StoreItemsId",
                        column: x => x.StoreItemsId,
                        principalTable: "StoreItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStoreItem_StoreItemsId",
                table: "CategoryStoreItem",
                column: "StoreItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryStoreItem");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "StoreItems");
        }
    }
}
