using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class desc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Teams",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 1,
                column: "description",
                value: "an FRC team");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 2,
                column: "description",
                value: "an FTC team");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 3,
                column: "description",
                value: "an FTC team");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 4,
                column: "description",
                value: "an FTC team");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "id",
                keyValue: 5,
                column: "description",
                value: "an FTC team");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Teams");
        }
    }
}
