using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.AddMusic
{
    public class AddMusicHandler(
        IMusicServiceContext context,
        IMusicService musicService) : IRequestHandler<AddMusicCommand, Result>
    {
        public async Task<Result> Handle(AddMusicCommand request, CancellationToken ct)
        {
            var matchedGenres = await context.MusicGenres
                .Where(g => request.Genres.Contains(g.Name))
                .ToListAsync(ct);

            var notFoundGenres = request.Genres.Except(matchedGenres.Select(g => g.Name)).ToList();

            if (notFoundGenres.Count != 0)
            {
                var missing = string.Join(", ", notFoundGenres);
                return Result.BadRequest($"Жанры не найдены: {missing}");
            }

            var music = await musicService.WriteMusicFileAndReturnAsync(request, ct);
            music.Genres = matchedGenres;

            await context.Musics.AddAsync(music, ct);
            await context.SaveChangesAsync(ct);

            return Result.Created();
        }
    }
}
