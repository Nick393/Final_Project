using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class @long : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                column: "UserName",
                value: "[Null]");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                column: "UserName",
                value: "[Null]");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                column: "UserName",
                value: "[Null]");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                column: "UserName",
                value: "[Null]");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                column: "UserName",
                value: "[Null]");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                column: "UserName",
                value: "[Null]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                column: "UserName",
                value: "Null");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                column: "UserName",
                value: "Null");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                column: "UserName",
                value: "Null");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                column: "UserName",
                value: "Null");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                column: "UserName",
                value: "Null");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                column: "UserName",
                value: "Null");
        }
    }
}
