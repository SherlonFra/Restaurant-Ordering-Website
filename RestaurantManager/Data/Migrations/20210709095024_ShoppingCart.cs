using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManager.Data.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AspNetUserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purchased = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "MenuitemShoppingCart",
                columns: table => new
                {
                    ItemsMenuItemId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsShoppingCartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuitemShoppingCart", x => new { x.ItemsMenuItemId, x.ShoppingCartsShoppingCartId });
                    table.ForeignKey(
                        name: "FK_MenuitemShoppingCart_Menuitems_ItemsMenuItemId",
                        column: x => x.ItemsMenuItemId,
                        principalTable: "Menuitems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuitemShoppingCart_ShoppingCarts_ShoppingCartsShoppingCartId",
                        column: x => x.ShoppingCartsShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuitemShoppingCart_ShoppingCartsShoppingCartId",
                table: "MenuitemShoppingCart",
                column: "ShoppingCartsShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuitemShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
