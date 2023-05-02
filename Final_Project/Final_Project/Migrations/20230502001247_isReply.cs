using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class isReply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isReply",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                column: "isReply",
                value: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                column: "isReply",
                value: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                column: "isReply",
                value: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                column: "isReply",
                value: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                column: "isReply",
                value: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                column: "isReply",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isReply",
                table: "Messages");
        }
    }
}
