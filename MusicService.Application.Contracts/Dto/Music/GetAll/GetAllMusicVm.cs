using MusicService.Domain.Models;

namespace MusicService.Application.Contracts.Dto.Music.GetAll
{
    public class GetAllMusicVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MusicPath { get; set; }
        public List<GetAllGenreVm> Genres { get; set; }
    }
}
