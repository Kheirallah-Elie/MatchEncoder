using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchEncoder.Server.Migrations
{
    /// <inheritdoc />
    public partial class ModUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 21, 9, 39, 368, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 21, 14, 39, 368, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3,
                column: "Hour",
                value: new DateTime(2024, 11, 24, 21, 19, 39, 368, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1,
                column: "MatchDateTime",
                value: new DateTime(2024, 12, 4, 21, 9, 39, 368, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2,
                column: "MatchDateTime",
                value: new DateTime(2024, 12, 14, 21, 9, 39, 368, DateTimeKind.Local).AddTicks(8063));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

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
    }
}
