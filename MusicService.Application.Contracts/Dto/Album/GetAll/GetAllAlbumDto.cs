namespace MusicService.Application.Contracts.Dto.Album.GetAll
{
    public class GetAllAlbumDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<GetAllAlbumMusicDto> Musics { get; set; }
    }
}
