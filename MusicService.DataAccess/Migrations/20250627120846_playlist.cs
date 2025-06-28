using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicService.Database.Migrations
{
    /// <inheritdoc />
    public partial class playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMusic_MusicGenre_GenresId",
                schema: "MusicSerivce",
                table: "GenreMusic");

            migrationBuilder.EnsureSchema(
                name: "MusicService");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "MusicSerivce",
                newName: "User",
                newSchema: "MusicService");

            migrationBuilder.RenameTable(
                name: "Music",
                schema: "MusicSerivce",
                newName: "Music",
                newSchema: "MusicService");

            migrationBuilder.RenameTable(
                name: "GenreMusic",
                schema: "MusicSerivce",
                newName: "GenreMusic",
                newSchema: "MusicService");

            migrationBuilder.RenameTable(
                name: "MusicGenre",
                schema: "MusicSerivce",
                newName: "Genre",
                newSchema: "MusicService");

            migrationBuilder.CreateTable(
                name: "Playlist",
                schema: "MusicService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Playlist_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_User_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "MusicService",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylist",
                schema: "MusicService",
                columns: table => new
                {
                    MusicsId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaylistsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylist", x => new { x.MusicsId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Music_MusicsId",
                        column: x => x.MusicsId,
                        principalSchema: "MusicService",
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylist_Playlist_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalSchema: "MusicService",
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylist_PlaylistsId",
                schema: "MusicService",
                table: "MusicPlaylist",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_CreatorId",
                schema: "MusicService",
                table: "Playlist",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMusic_Genre_GenresId",
                schema: "MusicService",
                table: "GenreMusic",
                column: "GenresId",
                principalSchema: "MusicService",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMusic_Genre_GenresId",
                schema: "MusicService",
                table: "GenreMusic");

            migrationBuilder.DropTable(
                name: "MusicPlaylist",
                schema: "MusicService");

            migrationBuilder.DropTable(
                name: "Playlist",
                schema: "MusicService");

            migrationBuilder.EnsureSchema(
                name: "MusicSerivce");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "MusicService",
                newName: "User",
                newSchema: "MusicSerivce");

            migrationBuilder.RenameTable(
                name: "Music",
                schema: "MusicService",
                newName: "Music",
                newSchema: "MusicSerivce");

            migrationBuilder.RenameTable(
                name: "GenreMusic",
                schema: "MusicService",
                newName: "GenreMusic",
                newSchema: "MusicSerivce");

            migrationBuilder.RenameTable(
                name: "Genre",
                schema: "MusicService",
                newName: "MusicGenre",
                newSchema: "MusicSerivce");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMusic_MusicGenre_GenresId",
                schema: "MusicSerivce",
                table: "GenreMusic",
                column: "GenresId",
                principalSchema: "MusicSerivce",
                principalTable: "MusicGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
