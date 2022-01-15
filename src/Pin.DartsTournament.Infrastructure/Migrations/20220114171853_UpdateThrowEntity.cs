using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pin.DartsTournament.Infrastructure.Migrations
{
    public partial class UpdateThrowEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Throws_Sets_LegId",
                table: "Throws");

            migrationBuilder.RenameColumn(
                name: "LegId",
                table: "Throws",
                newName: "SetId");

            migrationBuilder.RenameIndex(
                name: "IX_Throws_LegId",
                table: "Throws",
                newName: "IX_Throws_SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Throws_Sets_SetId",
                table: "Throws",
                column: "SetId",
                principalTable: "Sets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Throws_Sets_SetId",
                table: "Throws");

            migrationBuilder.RenameColumn(
                name: "SetId",
                table: "Throws",
                newName: "LegId");

            migrationBuilder.RenameIndex(
                name: "IX_Throws_SetId",
                table: "Throws",
                newName: "IX_Throws_LegId");

            migrationBuilder.AddForeignKey(
                name: "FK_Throws_Sets_LegId",
                table: "Throws",
                column: "LegId",
                principalTable: "Sets",
                principalColumn: "Id");
        }
    }
}
