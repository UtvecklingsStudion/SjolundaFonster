using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SjolundaFonster.Migrations
{
    /// <inheritdoc />
    public partial class ColorWhite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "#F2F2EB ", "Stockholmsvit" });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 6, "#647C80", "Öjablå" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "#647C80", "Öjablå" });
        }
    }
}
