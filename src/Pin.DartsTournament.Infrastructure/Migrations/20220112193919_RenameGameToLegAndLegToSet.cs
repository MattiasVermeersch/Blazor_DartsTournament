using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class RenameGameToLegAndLegToSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legs_Games_GameId",
                table: "Legs");

            migrationBuilder.DropForeignKey(
                name: "FK_Legs_Players_PlayerId",
                table: "Legs");

            migrationBuilder.DropForeignKey(
                name: "FK_Throws_Legs_LegId",
                table: "Throws");

            migrationBuilder.DropTable(
                name: "PlayerGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Legs",
                newName: "ScorePlayer2");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Legs",
                newName: "TournamentId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Legs",
                newName: "RefereeId");

            migrationBuilder.RenameIndex(
                name: "IX_Legs_PlayerId",
                table: "Legs",
                newName: "IX_Legs_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Legs_GameId",
                table: "Legs",
                newName: "IX_Legs_RefereeId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Legs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlayed",
                table: "Legs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScorePlayer1",
                table: "Legs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerLegs",
                columns: table => new
                {
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    LegId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerLegs", x => new { x.PlayerId, x.LegId });
                    table.ForeignKey(
                        name: "FK_PlayerLegs_Legs_LegId",
                        column: x => x.LegId,
                        principalTable: "Legs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerLegs_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: true),
                    LegId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sets_Legs_LegId",
                        column: x => x.LegId,
                        principalTable: "Legs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sets_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerLegs_LegId",
                table: "PlayerLegs",
                column: "LegId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_LegId",
                table: "Sets",
                column: "LegId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_PlayerId",
                table: "Sets",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legs_Referees_RefereeId",
                table: "Legs",
                column: "RefereeId",
                principalTable: "Referees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Legs_Tournaments_TournamentId",
                table: "Legs",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Throws_Sets_LegId",
                table: "Throws",
                column: "LegId",
                principalTable: "Sets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Legs_Referees_RefereeId",
                table: "Legs");

            migrationBuilder.DropForeignKey(
                name: "FK_Legs_Tournaments_TournamentId",
                table: "Legs");

            migrationBuilder.DropForeignKey(
                name: "FK_Throws_Sets_LegId",
                table: "Throws");

            migrationBuilder.DropTable(
                name: "PlayerLegs");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Legs");

            migrationBuilder.DropColumn(
                name: "IsPlayed",
                table: "Legs");

            migrationBuilder.DropColumn(
                name: "ScorePlayer1",
                table: "Legs");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Legs",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "ScorePlayer2",
                table: "Legs",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "RefereeId",
                table: "Legs",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Legs_TournamentId",
                table: "Legs",
                newName: "IX_Legs_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Legs_RefereeId",
                table: "Legs",
                newName: "IX_Legs_GameId");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPlayed = table.Column<bool>(type: "bit", nullable: false),
                    RefereeId = table.Column<long>(type: "bigint", nullable: true),
                    ScorePlayer1 = table.Column<int>(type: "int", nullable: false),
                    ScorePlayer2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerGames",
                columns: table => new
                {
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGames", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PlayerGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_RefereeId",
                table: "Games",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TournamentId",
                table: "Games",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGames_GameId",
                table: "PlayerGames",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Legs_Games_GameId",
                table: "Legs",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Legs_Players_PlayerId",
                table: "Legs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Throws_Legs_LegId",
                table: "Throws",
                column: "LegId",
                principalTable: "Legs",
                principalColumn: "Id");
        }
    }
}
