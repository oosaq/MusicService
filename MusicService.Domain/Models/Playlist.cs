namespace MusicService.Domain.Models
{
    public record Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public User Creator { get; set; }
        public Guid CreatorId { get; set; }

        public List<Music> Musics { get; set; }
    }
}
