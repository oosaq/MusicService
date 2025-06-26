using MediatR;
using Microsoft.AspNetCore.Http;
using MusicService.Domain.Common;

namespace MusicService.Application.Features.Commands.Musics.AddMusic
{
    public class AddMusicCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Musics { get; set; }

        public List<string> Genres { get; set; }
    }
}
