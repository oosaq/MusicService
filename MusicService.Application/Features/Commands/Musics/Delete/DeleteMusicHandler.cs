using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.Delete
{
    public class DeleteMusicHandler(
        IMusicServiceContext context) : IRequestHandler<DeleteMusicCommand, Result>
    {
        public async Task<Result> Handle(DeleteMusicCommand request, CancellationToken ct)
        {
            var musicFromDb = await context.Musics.FirstOrDefaultAsync(m => m.Id.Equals(request.MusicId), ct);
            if (musicFromDb == null)
                return Result.BadRequest("Музыка не найдена");

            context.Musics.Remove(musicFromDb);
            await context.SaveChangesAsync(ct);

            return Result.NoContent();
        }
    }
}
