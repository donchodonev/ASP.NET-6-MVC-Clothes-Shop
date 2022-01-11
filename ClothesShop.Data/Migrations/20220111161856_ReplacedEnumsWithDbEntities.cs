using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShop.Data.Migrations
{
    public partial class ReplacedEnumsWithDbEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Products",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "GenderGroup",
                table: "Products",
                newName: "GenderGroupId");

            migrationBuilder.RenameColumn(
                name: "Tier",
                table: "ClubCards",
                newName: "ClubCardTierId");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "AspNetUsers",
                newName: "GenderId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AgeGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ClubCardTier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubCardTier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenderGroupId",
                table: "Products",
                column: "GenderGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubCards_ClubCardTierId",
                table: "ClubCards",
                column: "ClubCardTierId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

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
                name: "FK_Products_Size_SizeId",
                table: "Products",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Products_Size_SizeId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ClubCardTier");

            migrationBuilder.DropTable(
                name: "GenderGroup");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Products_GenderGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SizeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ClubCards_ClubCardTierId",
                table: "ClubCards");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Products",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "GenderGroupId",
                table: "Products",
                newName: "GenderGroup");

            migrationBuilder.RenameColumn(
                name: "ClubCardTierId",
                table: "ClubCards",
                newName: "Tier");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "AspNetUsers",
                newName: "Gender");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "AgeGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
