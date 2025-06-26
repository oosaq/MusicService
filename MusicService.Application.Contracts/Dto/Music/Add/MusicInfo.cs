using MusicService.Domain.Models;

namespace MusicService.Application.Contracts.Dto.Music.Add
{
    public class MusicInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Bytes { get; set; }

        public List<MusicGenre> Genres { get; set; }
    }
}
