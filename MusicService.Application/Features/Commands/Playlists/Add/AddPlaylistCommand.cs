using MediatR;
using MusicService.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Application.Features.Commands.Playlists.Add
{
    public class AddPlaylistCommand : IRequest<Result>
    {

        [Required(ErrorMessage = "Название не может быть пустым")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание не может быть пустым")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Идентификаторы музыки не могут быть пустыми")]
        public List<Guid> MusicsIds { get; set; }
    }
}
