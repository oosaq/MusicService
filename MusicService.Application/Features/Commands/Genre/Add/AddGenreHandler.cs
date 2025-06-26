using MediatR;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Genre.Add
{
    public class AddGenreHandler(
        IMusicServiceContext context) : IRequestHandler<AddGenreCommand, Result>
    {
        public async Task<Result> Handle(AddGenreCommand request, CancellationToken ct)
        {
            if (context.MusicGenres.Any(g => g.Name == request.GenreName))
                return Result.BadRequest("Такой жанр уже есть");

            var genre = new MusicGenre()
            {
                Id = Guid.NewGuid(),
                Name = request.GenreName
            };

            await context.MusicGenres.AddAsync(genre);
            await context.SaveChangesAsync(ct);

            return Result.Created();
        }
    }
}
