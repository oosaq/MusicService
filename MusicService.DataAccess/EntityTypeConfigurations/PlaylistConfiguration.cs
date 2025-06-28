using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicService.Domain.Models;

namespace MusicService.Database.EntityTypeConfigurations
{
    public class PlaylistConfiguration(string tableName, string scheme) : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.HasKey(m => m.Id).HasName("Playlist_pkey");

            builder.ToTable(tableName, scheme);

            builder
                .HasOne(p => p.Creator)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.CreatorId);

            builder
                .HasMany(p => p.Musics)
                .WithMany(m => m.Playlists)
                .UsingEntity("MusicPlaylist");
        }
    }
}
