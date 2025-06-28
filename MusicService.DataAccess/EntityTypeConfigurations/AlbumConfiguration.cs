using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicService.Domain.Models;

namespace MusicService.Database.EntityTypeConfigurations
{
    public class AlbumConfiguration(string tableName, string scheme) : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(m => m.Id).HasName("Album_pkey");

            builder.ToTable(tableName, scheme);
        }
    }
}
