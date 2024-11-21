using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatchEncoder.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Team Alpha" },
                    { 2, "Team Beta" },
                    { 3, "Team Gamma" },
                    { 4, "Team Delta" }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "Id", "City", "Country", "DurationOfTimeout", "EventName", "MatchDateTime", "MatchNumber", "NumberOfQuarterTime", "TeamAId", "TeamBId" },
                values: new object[,]
                {
                    { 1, null, null, null, "Championship Finals", new DateTime(2024, 11, 24, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8126), 0, null, 1, 2 },
                    { 2, null, null, null, "Summer League", new DateTime(2024, 12, 4, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8166), 0, null, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "IsCaptain", "Name", "Number", "TeamId" },
                values: new object[,]
                {
                    { 1, false, "Alice", 10, 1 },
                    { 2, true, "Bob", 11, 1 },
                    { 3, false, "Charlie", 8, 2 },
                    { 4, false, "Daisy", 9, 2 },
                    { 5, true, "Eve", 15, 3 },
                    { 6, false, "Frank", 12, 3 },
                    { 7, false, "Grace", 13, 4 },
                    { 8, false, "Hank", 14, 4 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Hour", "MatchId", "PlayerId", "Points", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 14, 22, 6, 44, 69, DateTimeKind.Local).AddTicks(8213), 1, 1, 3, "Goal" },
                    { 2, new DateTime(2024, 11, 14, 22, 11, 44, 69, DateTimeKind.Local).AddTicks(8217), 1, 2, 0, "Foul" },
                    { 3, new DateTime(2024, 11, 14, 22, 16, 44, 69, DateTimeKind.Local).AddTicks(8220), 2, 5, 2, "Goal" }
                });

            migrationBuilder.InsertData(
                table: "MatchPlayer",
                columns: new[] { "MatchId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MatchPlayer",
                keyColumns: new[] { "MatchId", "PlayerId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
