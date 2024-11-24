using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchEncoder.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7327));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 19, 30, 38, 655, DateTimeKind.Local).AddTicks(7331));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 19, 35, 38, 655, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDateTime",
                value: new DateTime(2024, 12, 4, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchDateTime",
                value: new DateTime(2024, 12, 14, 19, 25, 38, 655, DateTimeKind.Local).AddTicks(7244));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hour",
                value: new DateTime(2024, 11, 14, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hour",
                value: new DateTime(2024, 11, 14, 22, 11, 44, 69, DateTimeKind.Local).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hour",
                value: new DateTime(2024, 11, 14, 22, 16, 44, 69, DateTimeKind.Local).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDateTime",
                value: new DateTime(2024, 11, 24, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchDateTime",
                value: new DateTime(2024, 12, 4, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8166));
        }
    }
}
