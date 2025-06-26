namespace MusicService.Domain.Models
{
    public class MusicGenre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Music> Musics { get; set; }
    }
}
