﻿namespace MusicService.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Playlist> Playlists { get; set; }
    }
}
