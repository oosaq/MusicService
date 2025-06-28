using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Database.EntityTypeConfigurations;
using MusicService.Domain.Models;

namespace MusicService.Database
{
    public class MusicServiceContext : DbContext, IMusicServiceContext
    {
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<MusicGenre> MusicGenres { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }

        public MusicServiceContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration("Music", "MusicService"));
            modelBuilder.ApplyConfiguration(new UserConfiguration("User", "MusicService"));
            modelBuilder.ApplyConfiguration(new MusicGenreConfiguration("Genre", "MusicService"));
            modelBuilder.ApplyConfiguration(new PlaylistConfiguration("Playlist", "MusicService"));
            modelBuilder.ApplyConfiguration(new AlbumConfiguration("Album", "MusicService"));
        }
    }
}
