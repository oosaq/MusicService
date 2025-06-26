using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicService.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MusicSerivce");

            migrationBuilder.CreateTable(
                name: "Music",
                schema: "MusicSerivce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MusicPath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Music_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenre",
                schema: "MusicSerivce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MusicGenre_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "MusicSerivce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreMusic",
                schema: "MusicSerivce",
                columns: table => new
                {
                    GenresId = table.Column<Guid>(type: "uuid", nullable: false),
                    MusicsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMusic", x => new { x.GenresId, x.MusicsId });
                    table.ForeignKey(
                        name: "FK_GenreMusic_MusicGenre_GenresId",
                        column: x => x.GenresId,
                        principalSchema: "MusicSerivce",
                        principalTable: "MusicGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMusic_Music_MusicsId",
                        column: x => x.MusicsId,
                        principalSchema: "MusicSerivce",
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMusic_MusicsId",
                schema: "MusicSerivce",
                table: "GenreMusic",
                column: "MusicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMusic",
                schema: "MusicSerivce");

            migrationBuilder.DropTable(
                name: "User",
                schema: "MusicSerivce");

            migrationBuilder.DropTable(
                name: "MusicGenre",
                schema: "MusicSerivce");

            migrationBuilder.DropTable(
                name: "Music",
                schema: "MusicSerivce");
        }
    }
}
