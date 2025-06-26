using MediatR;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Genre.Add
{
    public class AddGenreCommand : IRequest<Result>
    {
        public string GenreName { get; set; }
    }
}
