using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class AddedNewPropertiesToSizeEntityUpdatedProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SizeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Sizes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Sizes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ModifiedOn",
                table: "Sizes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductId",
                table: "Sizes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Products_ProductId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ProductId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sizes");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sizes_SizeId",
                table: "Products",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
