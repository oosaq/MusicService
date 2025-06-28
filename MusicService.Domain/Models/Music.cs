namespace MusicService.Domain.Models
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MusicPath { get; set; }

        public List<MusicGenre> Genres { get; set; }
        public List<Playlist> Playlists { get; set; }

        public Guid? AlbumId { get; set; }
        public Album? Album { get; set; }

    }
}
