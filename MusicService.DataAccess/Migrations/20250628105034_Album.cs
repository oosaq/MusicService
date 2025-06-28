using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicService.Database.Migrations
{
    /// <inheritdoc />
    public partial class Album : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                schema: "MusicService",
                table: "Music",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_AlbumId",
                schema: "MusicService",
                table: "Music",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Albums_AlbumId",
                schema: "MusicService",
                table: "Music",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Albums_AlbumId",
                schema: "MusicService",
                table: "Music");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Music_AlbumId",
                schema: "MusicService",
                table: "Music");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                schema: "MusicService",
                table: "Music");
        }
    }
}
