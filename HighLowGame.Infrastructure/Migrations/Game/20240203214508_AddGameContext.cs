using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighLowGame.Infrastructure.Migrations.Game
{
    /// <inheritdoc />
    public partial class AddGameContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerOneId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerTwoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerOneScore = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerTwoScore = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSession_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerMove",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChooseHigher = table.Column<bool>(type: "INTEGER", nullable: true),
                    NumberChosen = table.Column<int>(type: "INTEGER", nullable: true),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMove", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMove_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_GameId",
                table: "GameSession",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMove_GameId",
                table: "PlayerMove",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSession");

            migrationBuilder.DropTable(
                name: "PlayerMove");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
