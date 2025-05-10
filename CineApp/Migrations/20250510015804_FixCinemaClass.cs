using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineApp.Migrations
{
    /// <inheritdoc />
    public partial class FixCinemaClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMovies_CinemaHalls_CinemaId",
                table: "CinemaMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls");

            migrationBuilder.RenameTable(
                name: "CinemaHalls",
                newName: "Cinema");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinema",
                table: "Cinema",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMovies_Cinema_CinemaId",
                table: "CinemaMovies",
                column: "CinemaId",
                principalTable: "Cinema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaMovies_Cinema_CinemaId",
                table: "CinemaMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinema",
                table: "Cinema");

            migrationBuilder.RenameTable(
                name: "Cinema",
                newName: "CinemaHalls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaHalls",
                table: "CinemaHalls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaMovies_CinemaHalls_CinemaId",
                table: "CinemaMovies",
                column: "CinemaId",
                principalTable: "CinemaHalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
