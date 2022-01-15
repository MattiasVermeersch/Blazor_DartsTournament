using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class UpdatePlayerSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Losses", "Name", "TournamentId", "Wins" },
                values: new object[] { 5L, 0, "Pablo Picasso", 100L, 0 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Losses", "Name", "TournamentId", "Wins" },
                values: new object[] { 6L, 0, "Johan Vermeer", 100L, 0 });
        }
    }
}
