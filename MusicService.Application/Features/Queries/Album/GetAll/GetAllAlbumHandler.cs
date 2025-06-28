using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Contracts.Dto.Album.GetAll;
using MusicService.Application.Contracts.Dto.Music.GetAll;
using MusicService.Application.Interfaces;

namespace MusicService.Application.Features.Queries.Album.GetAll
{
    public class GetAllAlbumHandler(
        IMusicServiceContext context) : IRequestHandler<GetAllAlbumQuery, List<GetAllAlbumDto>>
    {
        public async Task<List<GetAllAlbumDto>> Handle(GetAllAlbumQuery request, CancellationToken ct)
        {
            return await context
                .Albums
                .Include(a => a.Tracks)
                .Select(a => new GetAllAlbumDto()
                {
                    ReleaseDate = a.ReleaseDate ,
                    Musics = a.Tracks.Select(g => new GetAllAlbumMusicDto() { Name = g.Name }).ToList(),
                    Title = a.Title
                })
                .ToListAsync(ct);
        }
    }
}
