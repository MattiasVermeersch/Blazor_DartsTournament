using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class FirstSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "GameId", "Losses", "Name", "TournamentId", "Wins" },
                values: new object[,]
                {
                    { 1L, null, 0, "Jane Doe", null, 0 },
                    { 2L, null, 0, "John Doe", null, 0 },
                    { 3L, null, 0, "Harry Potter", null, 0 },
                    { 4L, null, 0, "Mr. Anderson", null, 0 },
                    { 5L, null, 0, "Pablo Picasso", null, 0 },
                    { 6L, null, 0, "Johan Vermeer", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Referees",
                columns: new[] { "Id", "Name", "TournamentId" },
                values: new object[,]
                {
                    { 30L, "Lector Deboosere", null },
                    { 31L, "Lector Derdeyn", null }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                column: "Id",
                value: 100L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 100L);
        }
    }
}
