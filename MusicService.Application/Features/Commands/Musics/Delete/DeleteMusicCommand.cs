using MediatR;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.Delete
{
    public class DeleteMusicCommand : IRequest<Result>
    {
        public Guid MusicId { get; set; }
    }
}
