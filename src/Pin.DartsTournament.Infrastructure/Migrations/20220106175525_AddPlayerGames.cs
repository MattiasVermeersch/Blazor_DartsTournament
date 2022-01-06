using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class AddPlayerGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_GameId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "Players",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
