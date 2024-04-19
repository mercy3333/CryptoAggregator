using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d8e8e0d-bb58-441f-9c51-593acc7f471e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9ab9e02-0f5a-4266-8002-b1652810508a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be6b3d97-562f-4f84-8f9f-dc5478e5bdc4", null, "Admin", "ADMIN" },
                    { "ebd9f437-8a06-4ba3-aaba-d2f72678d990", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be6b3d97-562f-4f84-8f9f-dc5478e5bdc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd9f437-8a06-4ba3-aaba-d2f72678d990");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d8e8e0d-bb58-441f-9c51-593acc7f471e", null, "User", "USER" },
                    { "f9ab9e02-0f5a-4266-8002-b1652810508a", null, "Admin", "ADMIN" }
                });
        }
    }
}
