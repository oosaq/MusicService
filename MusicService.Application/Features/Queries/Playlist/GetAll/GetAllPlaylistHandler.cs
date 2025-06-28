using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Contracts.Dto.Playlist.GetAll;
using MusicService.Application.Interfaces;

namespace MusicService.Application.Features.Queries.Playlist.GetAll
{
    public class GetAllPlaylistHandler(
        IMusicServiceContext context) : IRequestHandler<GetAllPlaylistsCommand, List<GetAllPlaylistDto>>
    {
        public async Task<List<GetAllPlaylistDto>> Handle(GetAllPlaylistsCommand request, CancellationToken ct)
        {
            return await context
                .Playlists
                .Include(p => p.Musics)
                .Select(p => new GetAllPlaylistDto()
                {
                    Description = p.Description,
                    Name = p.Name,
                    Musics = p.Musics.Select(m => new GetAllMusicDto() { Description = m.Description, MusicPath = m.MusicPath, Name = m.Name }).ToList()
                })
                .ToListAsync(ct);
        }
    }
}
