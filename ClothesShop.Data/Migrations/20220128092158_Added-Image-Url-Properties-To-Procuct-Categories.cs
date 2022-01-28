using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class AddedImageUrlPropertiesToProcuctCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "AgeGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "AgeGroups");
        }
    }
}
