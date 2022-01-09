using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TournamentId",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TournamentId",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3L,
                column: "TournamentId",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 30L,
                column: "TournamentId",
                value: 100L);

            migrationBuilder.UpdateData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 31L,
                column: "TournamentId",
                value: 100L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1L,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2L,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3L,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 30L,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Referees",
                keyColumn: "Id",
                keyValue: 31L,
                column: "TournamentId",
                value: null);
        }
    }
}
