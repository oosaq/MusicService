using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Contracts.Dto.Music.GetAll;
using MusicService.Application.Interfaces;

namespace MusicService.Application.Features.Queries.GetAll
{
    public class GetAllMusicHandler(
        IMusicServiceContext context) : IRequestHandler<GetAllMusicQuery, List<MusicVm>>
    {
        public async Task<List<MusicVm>> Handle(GetAllMusicQuery request, CancellationToken ct)
        {
            return await context
                .Musics
                .Include(m => m.Genres)
                .Select(m => new MusicVm()
                {
                    Id = m.Id,
                    Description = m.Description,
                    Genres = m.Genres.Select(g => new GenreVm() { Name = g.Name }).ToList(),
                    MusicPath = m.MusicPath,
                    Name = m.Name
                })
                .ToListAsync(ct);
        }
    }
}
