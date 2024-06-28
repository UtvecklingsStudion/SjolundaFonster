using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SjolundaFonster.Migrations
{
    /// <inheritdoc />
    public partial class changeWindowClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColors_ProductColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductColors_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductModels_ModelId",
                table: "Products",
                column: "ModelId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColors_ColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductModels_ModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModelId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductColorId",
                table: "Products",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductModelId",
                table: "Products",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductColors_ProductColorId",
                table: "Products",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products",
                column: "ProductModelId",
                principalTable: "ProductModels",
                principalColumn: "Id");
        }
    }
}
