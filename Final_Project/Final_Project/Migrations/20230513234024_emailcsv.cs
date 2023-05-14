using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class emailcsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Emails_Emailid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Emailid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Emailid",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "emailsCSV",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emailsCSV",
                table: "Emails");

            migrationBuilder.AddColumn<int>(
                name: "Emailid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Emailid",
                table: "AspNetUsers",
                column: "Emailid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Emails_Emailid",
                table: "AspNetUsers",
                column: "Emailid",
                principalTable: "Emails",
                principalColumn: "id");
        }
    }
}
