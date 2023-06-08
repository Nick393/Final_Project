using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class Slips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "slips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eventStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    eventEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isMain = table.Column<bool>(type: "bit", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signed = table.Column<bool>(type: "bit", nullable: false),
                    Slipid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slips", x => x.id);
                    table.ForeignKey(
                        name: "FK_slips_slips_Slipid",
                        column: x => x.Slipid,
                        principalTable: "slips",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_slips_Slipid",
                table: "slips",
                column: "Slipid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "slips");
        }
    }
}
