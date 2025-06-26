namespace MusicService.Domain.Models
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MusicPath { get; set; }

        public List<MusicGenre> Genres { get; set; }
    }
}
