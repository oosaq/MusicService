namespace MusicService.Domain.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }

        public ICollection<Music> Tracks { get; set; }
    }
}
