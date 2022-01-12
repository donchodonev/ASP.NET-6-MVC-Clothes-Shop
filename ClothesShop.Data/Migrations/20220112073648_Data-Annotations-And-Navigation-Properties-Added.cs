using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class DataAnnotationsAndNavigationPropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GenderGroup_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubCards_ClubCardTier_ClubCardTierId",
                table: "ClubCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenderGroup_GenderGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddress_AspNetUsers_ClientId",
                table: "ShippingAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderGroup",
                table: "GenderGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubCardTier",
                table: "ClubCardTier");

            migrationBuilder.RenameTable(
                name: "ShippingAddress",
                newName: "ShippingAddresses");

            migrationBuilder.RenameTable(
                name: "GenderGroup",
                newName: "GenderGroups");

            migrationBuilder.RenameTable(
                name: "ClubCardTier",
                newName: "ClubCardTiers");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddress_ClientId",
                table: "ShippingAddresses",
                newName: "IX_ShippingAddresses_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ShoppingCarts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ModifiedOn",
                table: "ShoppingCarts",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderGroups",
                table: "GenderGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubCardTiers",
                table: "ClubCardTiers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GenderGroups_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "GenderGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubCards_ClubCardTiers_ClubCardTierId",
                table: "ClubCards",
                column: "ClubCardTierId",
                principalTable: "ClubCardTiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenderGroups_GenderGroupId",
                table: "Products",
                column: "GenderGroupId",
                principalTable: "GenderGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GenderGroups_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubCards_ClubCardTiers_ClubCardTierId",
                table: "ClubCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_GenderGroups_GenderGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_ClientId",
                table: "ShippingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenderGroups",
                table: "GenderGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubCardTiers",
                table: "ClubCardTiers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ShippingAddresses",
                newName: "ShippingAddress");

            migrationBuilder.RenameTable(
                name: "GenderGroups",
                newName: "GenderGroup");

            migrationBuilder.RenameTable(
                name: "ClubCardTiers",
                newName: "ClubCardTier");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddresses_ClientId",
                table: "ShippingAddress",
                newName: "IX_ShippingAddress_ClientId");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingAddressId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenderGroup",
                table: "GenderGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubCardTier",
                table: "ClubCardTier",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GenderGroup_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "GenderGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClubCards_ClubCardTier_ClubCardTierId",
                table: "ClubCards",
                column: "ClubCardTierId",
                principalTable: "ClubCardTier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GenderGroup_GenderGroupId",
                table: "Products",
                column: "GenderGroupId",
                principalTable: "GenderGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddress_AspNetUsers_ClientId",
                table: "ShippingAddress",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
