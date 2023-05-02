using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class parentid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                column: "ParentID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                column: "ParentID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                column: "ParentID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                column: "ParentID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                column: "ParentID",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                column: "ParentID",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Messages");
        }
    }
}
