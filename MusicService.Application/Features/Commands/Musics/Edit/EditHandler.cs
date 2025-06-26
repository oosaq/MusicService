using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.Edit
{
    public class EditHandler(
        IMusicServiceContext context) : IRequestHandler<EditCommand, Result>
    {
        public async Task<Result> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var music = await context.Musics
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == request.MusicId, cancellationToken);

            if (music == null)
                return Result.BadRequest("Музыка не найдена");

            if (!string.IsNullOrWhiteSpace(request.NewName))
                music.Name = request.NewName;

            if (!string.IsNullOrWhiteSpace(request.NewDescription))
                music.Description = request.NewDescription;

            if (request.NewGenres is { Count: > 0 })
            {
                var matchedGenres = await context.MusicGenres
                    .Where(g => request.NewGenres.Contains(g.Name))
                    .ToListAsync(cancellationToken);

                var notFoundGenres = request.NewGenres
                    .Except(matchedGenres.Select(g => g.Name))
                    .ToList();

                if (notFoundGenres.Any())
                {
                    var missing = string.Join(", ", notFoundGenres);
                    return Result.BadRequest($"Жанры не найдены: {missing}");
                }

                // Обновляем жанры
                music.Genres.Clear(); // если связь many-to-many
                foreach (var genre in matchedGenres)
                    music.Genres.Add(genre);
            }

            await context.SaveChangesAsync(cancellationToken);
            return Result.NoContent();
        }
    }
}
