using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class success : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "succeed",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SMTPConfig",
                columns: new[] { "id", "emailAddress", "port", "provider", "smtpKey" },
                values: new object[] { -1, "keymailservice@gmail.com", 587, "smtp.gmail.com", "vmgadsqskmtwnvjp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SMTPConfig",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "succeed",
                table: "Emails");
        }
    }
}
