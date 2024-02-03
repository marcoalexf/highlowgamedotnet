using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighLowGame.Infrastructure.Migrations.GameSession
{
    /// <inheritdoc />
    public partial class AddGameSessionContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerOneId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerTwoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerOneScore = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerTwoScore = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFinished = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_PlayerOneId_PlayerTwoId",
                table: "GameSessions",
                columns: new[] { "PlayerOneId", "PlayerTwoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSessions");
        }
    }
}
