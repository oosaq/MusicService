using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Contracts.Dto.Music.GetAll;
using MusicService.Application.Interfaces;

namespace MusicService.Application.Features.Queries.Musics.GetAllMusic
{
    public class GetAllMusicHandler(
        IMusicServiceContext context) : IRequestHandler<GetAllMusicQuery, List<GetAllMusicVm>>
    {
        public async Task<List<GetAllMusicVm>> Handle(GetAllMusicQuery request, CancellationToken ct)
        {
            return await context
                .Musics
                .Include(m => m.Genres)
                .Select(m => new GetAllMusicVm()
                {
                    Id = m.Id,
                    Description = m.Description,
                    Genres = m.Genres.Select(g => new GetAllGenreVm() { Name = g.Name }).ToList(),
                    MusicPath = m.MusicPath,
                    Name = m.Name
                })
                .ToListAsync(ct);
        }
    }
}
