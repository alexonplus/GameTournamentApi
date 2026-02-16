using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTournamentApi.Migrations
{
    /// <inheritdoc />
    public partial class ActualDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "MaxPlayers", "Title" },
                values: new object[] { 1, new DateTime(2026, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Finals", 100, "Pro League 2026" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
