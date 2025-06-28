using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicService.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlbumConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Albums_AlbumId",
                schema: "MusicService",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album",
                newSchema: "MusicService");

            migrationBuilder.AddPrimaryKey(
                name: "Album_pkey",
                schema: "MusicService",
                table: "Album",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Album_AlbumId",
                schema: "MusicService",
                table: "Music",
                column: "AlbumId",
                principalSchema: "MusicService",
                principalTable: "Album",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music_Album_AlbumId",
                schema: "MusicService",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "Album_pkey",
                schema: "MusicService",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                schema: "MusicService",
                newName: "Albums");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Albums_AlbumId",
                schema: "MusicService",
                table: "Music",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");
        }
    }
}
