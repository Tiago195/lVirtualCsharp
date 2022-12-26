using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lVirtual.ProductApi.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Stock" },
                values: new object[] { 1, 1, "Caderno Espiral", "carderno1.jpg", "Caderno", 7.55m, 10L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Stock" },
                values: new object[] { 2, 1, "Lápis Preto", "lapis1.jpg", "Lápis", 3.45m, 20L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Stock" },
                values: new object[] { 3, 2, "Clipis para papel", "clipis1.jpg", "Clips", 5.33m, 50L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
