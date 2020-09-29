using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaJogos.Infrastructure.Data.Migrations
{
    public partial class TableBorrowedGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowedGame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false),
                    IdGame = table.Column<Guid>(nullable: false),
                    IdFriend = table.Column<Guid>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedGame_Friend_IdFriend",
                        column: x => x.IdFriend,
                        principalTable: "Friend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BorrowedGame_Game_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BorrowedGame_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedGame_IdFriend",
                table: "BorrowedGame",
                column: "IdFriend");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedGame_IdGame",
                table: "BorrowedGame",
                column: "IdGame");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedGame_IdUser",
                table: "BorrowedGame",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedGame");
        }
    }
}
