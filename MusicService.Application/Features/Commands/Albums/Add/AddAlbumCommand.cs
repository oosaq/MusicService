using MediatR;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Albums.Add
{
    public class AddAlbumCommand : IRequest<Result>
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Guid> MusicsIds { get; set; }
    }
}
