using Microsoft.EntityFrameworkCore;
using MusicService.Domain.Models;

namespace MusicService.Application.Interfaces
{
    public interface IMusicServiceContext
    {
        DbSet<Music> Musics { get; set; }
        DbSet<MusicGenre> MusicGenres { get; set; }
        DbSet<User> Users { get; set; }


        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
