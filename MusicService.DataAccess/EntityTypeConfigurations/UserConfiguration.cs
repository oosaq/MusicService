using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MusicService.Domain.Models;

namespace MusicService.Database.EntityTypeConfigurations
{
    public class UserConfiguration(string tableName, string scheme) : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id).HasName("User_pkey");

            builder.ToTable(tableName, scheme);
        }
    }
}
