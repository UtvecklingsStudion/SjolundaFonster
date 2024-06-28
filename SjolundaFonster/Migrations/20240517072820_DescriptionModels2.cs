using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SjolundaFonster.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Anno 1900 är en fönstermodell med två spröjs i varje fönsterbåge. Vanlint förekommande i svensk arkitektur under byggtiden kring 1900.");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Anno 1920 är en fönstermodell med en spröjs i varje fönsterbåge. Vanlint förekommande i svensk arkitektur under byggtiden kring 1920.");

            migrationBuilder.UpdateData(
                table: "ProductModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Anno 1920 är en fönstermodell utan spröjs. Vanlint förekommande i svensk arkitektur under byggtiden kring 1930.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductModels");
        }
    }
}
