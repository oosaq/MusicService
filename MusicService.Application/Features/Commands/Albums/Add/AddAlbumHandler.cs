using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Albums.Add
{
    public class AddAlbumHandler(
        IMusicServiceContext context) : IRequestHandler<AddAlbumCommand, Result>
    {
        public async Task<Result> Handle(AddAlbumCommand request, CancellationToken ct)
        {
            var matchedMusics = await context.Musics
                .Where(g => request.MusicsIds.Contains(g.Id))
                .ToListAsync(ct);

            var notFoundGenres = request.MusicsIds.Except(matchedMusics.Select(m => m.Id)).ToList();

            if (notFoundGenres.Count != 0)
            {
                var missing = string.Join(", ", notFoundGenres);
                return Result.BadRequest($"Идентификатор музыки не найден: {missing}");
            }

            var album = new Album()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                Tracks = matchedMusics
            };

            await context.Albums.AddAsync(album);
            await context.SaveChangesAsync(ct);

            return Result.Created();
        }
    }
}
