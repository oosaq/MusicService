using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Application.Services;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Playlists.Add
{
    public class AddPlaylistHandler(
        IMusicServiceContext context,
        CurrentUserService currentUserService) : IRequestHandler<AddPlaylistCommand, Result>
    {
        public async Task<Result> Handle(AddPlaylistCommand request, CancellationToken ct)
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

            var playlist = new Playlist()
            {
                Id = Guid.NewGuid(),
                CreatorId = currentUserService.UserId,
                Description = request.Description,
                Musics = matchedMusics,
                Name = request.Name
            };

            await context.Playlists.AddAsync(playlist, ct);

            await context.SaveChangesAsync(ct);

            return Result.NoContent();
        }
    }
}
