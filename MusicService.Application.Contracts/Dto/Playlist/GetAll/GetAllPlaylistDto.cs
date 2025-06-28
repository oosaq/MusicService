using MusicService.Domain.Models;

namespace MusicService.Application.Contracts.Dto.Playlist.GetAll
{
    public class GetAllPlaylistDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GetAllMusicDto> Musics { get; set; }
    }
}
