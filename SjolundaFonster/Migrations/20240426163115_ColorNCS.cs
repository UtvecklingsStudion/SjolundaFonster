using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SjolundaFonster.Migrations
{
    /// <inheritdoc />
    public partial class ColorNCS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NCS",
                table: "ProductColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 1,
                column: "NCS",
                value: "0500-N");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 2,
                column: "NCS",
                value: "0500-N");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 3,
                column: "NCS",
                value: "0500-N");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 4,
                column: "NCS",
                value: "0500-N");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 5,
                column: "NCS",
                value: "0500-N");

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 6,
                column: "NCS",
                value: "0500-N");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NCS",
                table: "ProductColors");
        }
    }
}
