using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaJogos.Infrastructure.Data.Migrations
{
    public partial class ChangeTableBorrowedGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BorrowedGame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BorrowedGame",
                type: "datetime2",
                nullable: true);
        }
    }
}
