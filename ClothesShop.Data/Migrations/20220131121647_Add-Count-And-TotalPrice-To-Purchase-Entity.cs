using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class AddCountAndTotalPriceToPurchaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Purchases");
        }
    }
}
