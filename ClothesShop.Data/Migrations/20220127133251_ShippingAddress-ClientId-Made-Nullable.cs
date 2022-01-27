using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class ShippingAddressClientIdMadeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ShippingAddresses",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ShippingAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
