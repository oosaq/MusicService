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
        public MusicServiceContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MusicConfiguration("Music", "MusicSerivce"));
            modelBuilder.ApplyConfiguration(new UserConfiguration("User", "MusicSerivce"));
            modelBuilder.ApplyConfiguration(new MusicGenreConfiguration("MusicGenre", "MusicSerivce"));
        }
    }
}
