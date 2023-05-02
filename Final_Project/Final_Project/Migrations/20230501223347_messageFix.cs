using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class messageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Messageid",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -6,
                column: "Messageid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -5,
                column: "Messageid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -4,
                column: "Messageid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -3,
                column: "Messageid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -2,
                column: "Messageid",
                value: null);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: -1,
                column: "Messageid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Messageid",
                table: "Messages",
                column: "Messageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Messages_Messageid",
                table: "Messages",
                column: "Messageid",
                principalTable: "Messages",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Messages_Messageid",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_Messageid",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Messageid",
                table: "Messages");
        }
    }
}
