using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicService.Domain.Models;

namespace MusicService.Database.EntityTypeConfigurations
{
    public class MusicConfiguration(string tableName, string scheme) : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(m => m.Id).HasName("Music_pkey");

            builder.ToTable(tableName, scheme);

            builder
                .HasOne(m => m.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(m => m.AlbumId);
        }
    }
}
