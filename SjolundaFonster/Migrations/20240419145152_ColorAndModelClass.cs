using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SjolundaFonster.Migrations
{
    /// <inheritdoc />
    public partial class ColorAndModelClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Products",
                newName: "ModelId");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Products",
                newName: "ColorId");

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

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "#647C80", "Öjablå" },
                    { 2, "#4F7D47", "Köpenhamngrön" },
                    { 3, "#EAC67A", "Sandgul" },
                    { 4, "#B4BCAD", "Varmgrå" },
                    { 5, "#8E2011", "Engelsk röd" }
                });

            migrationBuilder.InsertData(
                table: "ProductModels",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "anno_1900", "Anno 1900" },
                    { 2, "anno_1920", "Anno 1920" },
                    { 3, "anno_1930", "Anno 1930" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColors_ProductColorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductModels_ProductModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductModels");

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

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Products",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Products",
                newName: "Color");
        }
    }
}
