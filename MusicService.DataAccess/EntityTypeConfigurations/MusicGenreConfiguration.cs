using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicService.Domain.Models;

namespace MusicService.Database.EntityTypeConfigurations
{
    public class MusicGenreConfiguration(string tableName, string scheme) : IEntityTypeConfiguration<MusicGenre>
    {
        public void Configure(EntityTypeBuilder<MusicGenre> builder)
        {
            builder.HasKey(m => m.Id).HasName("MusicGenre_pkey");

            builder.ToTable(tableName, scheme);

            builder
                .HasMany(m => m.Musics)
                .WithMany(g => g.Genres)
                .UsingEntity("GenreMusic");
        }
    }
}
