using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Messageid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Messageid",
                table: "AspNetUsers",
                column: "Messageid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Messages_Messageid",
                table: "AspNetUsers",
                column: "Messageid",
                principalTable: "Messages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Messages_Messageid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Messageid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Messageid",
                table: "AspNetUsers");
        }
    }
}
