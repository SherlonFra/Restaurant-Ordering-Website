using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManager.Data.Migrations
{
    public partial class MoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryOptions",
                columns: table => new
                {
                    DeliveryOptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DeliveryType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOptions", x => x.DeliveryOptionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryOptions");
        }
    }
}
