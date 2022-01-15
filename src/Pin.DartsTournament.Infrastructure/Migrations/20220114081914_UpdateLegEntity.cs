using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class UpdateLegEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrentlyPlayingId",
                table: "Legs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WinnerId",
                table: "Legs",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentlyPlayingId",
                table: "Legs");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Legs");
        }
    }
}
