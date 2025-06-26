using MediatR;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.Edit
{
    public class EditCommand : IRequest<Result>
    {
        public Guid MusicId { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public List<string> NewGenres { get; set; }
    }
}
