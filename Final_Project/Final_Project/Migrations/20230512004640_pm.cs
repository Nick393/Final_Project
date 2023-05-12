using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class pm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recip",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isPM",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "Body", "Recip", "Title", "isPM" },
                values: new object[] { "Body", "", "Title", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recip",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "isPM",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body1", "Message5" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body5", "Message1" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body4", "Message2" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body3", "Message3" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body2", "Message4" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                columns: new[] { "Body", "Title" },
                values: new object[] { "Body1", "Message5" });
        }
    }
}
