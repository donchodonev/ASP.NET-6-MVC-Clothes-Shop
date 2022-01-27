using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class ShippingAddressRenamedToShippingDetailsNowHoldRecipientNamesPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses");

            migrationBuilder.RenameTable(
                name: "ShippingAddresses",
                newName: "ShippingDetails");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "Orders",
                newName: "ShippingDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                newName: "IX_Orders_ShippingDetailsId");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "AspNetUsers",
                newName: "ShippingDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingDetails",
                newName: "IX_ShippingDetails_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingDetails",
                table: "ShippingDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingDetailsId",
                table: "Orders",
                column: "ShippingDetailsId",
                principalTable: "ShippingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetails_AspNetUsers_ClientId",
                table: "ShippingDetails",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingDetailsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetails_AspNetUsers_ClientId",
                table: "ShippingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingDetails",
                table: "ShippingDetails");

            migrationBuilder.RenameTable(
                name: "ShippingDetails",
                newName: "ShippingAddresses");

            migrationBuilder.RenameColumn(
                name: "ShippingDetailsId",
                table: "Orders",
                newName: "ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShippingDetailsId",
                table: "Orders",
                newName: "IX_Orders_ShippingAddressId");

            migrationBuilder.RenameColumn(
                name: "ShippingDetailsId",
                table: "AspNetUsers",
                newName: "ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingDetails_ClientId",
                table: "ShippingAddresses",
                newName: "IX_ShippingAddresses_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId",
                principalTable: "ShippingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
