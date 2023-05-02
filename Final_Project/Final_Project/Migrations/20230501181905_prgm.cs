using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class prgm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prgm",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 1,
                column: "Prgm",
                value: "FRC");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 2,
                column: "Prgm",
                value: "FRC");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 3,
                column: "Prgm",
                value: "FRC");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 4,
                column: "Prgm",
                value: "FRC");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 5,
                column: "Prgm",
                value: "FRC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prgm",
                table: "Teams");
        }
    }
}
