using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpaceSystemWebData.Migrations
{
    /// <inheritdoc />
    public partial class seededplanetsandstar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "BoughtId", "CustomerId", "GravitationalPull", "Moons", "Name", "OrbitInDays" },
                values: new object[,]
                {
                    { 1, 0, 0, 3.7m, 0, "Mercury", 88 },
                    { 2, 0, 0, 8.9m, 0, "Venus", 225 },
                    { 3, 0, 0, 9.8m, 1, "Earth", 365 },
                    { 4, 0, 0, 3.7m, 2, "Mars", 687 },
                    { 5, 0, 0, 23.1m, 57, "Jupiter", 4333 },
                    { 6, 0, 0, 9m, 63, "Saturn", 10759 },
                    { 7, 0, 0, 8.7m, 27, "Uranus", 30687 },
                    { 8, 0, 0, 11m, 14, "Neptune", 60190 }
                });

            migrationBuilder.InsertData(
                table: "Stars",
                columns: new[] { "Id", "BoughtId", "Brightness", "CustomerId", "Name", "Temperature" },
                values: new object[] { 1, 0, -26.74m, 0, "Sun", 5778 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stars",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
