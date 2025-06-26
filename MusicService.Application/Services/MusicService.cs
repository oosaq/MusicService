using MusicService.Application.Features.Commands.Musics.AddMusic;
using MusicService.Application.Interfaces;
using MusicService.Domain.Models;

namespace MusicService.Application.Services
{
    public class MusicService : IMusicService
    {
        public async Task<Music> WriteMusicFileAndReturnAsync(AddMusicCommand musicsInfos, CancellationToken ct)
        {
            byte[] musicBytes;

            using var memory = new MemoryStream();
            await musicsInfos.Musics.CopyToAsync(memory, ct);
            musicBytes = memory.ToArray();

            if (!Directory.Exists("wwwroot/"))
                Directory.CreateDirectory("wwwroot/");

            Directory.SetCurrentDirectory("wwwroot/");

            if (!Directory.Exists("musics/"))
                Directory.CreateDirectory("musics/");

            var musics = new List<Music>();

            var musicId = Guid.NewGuid();

            if (!Directory.Exists($"musics/{musicId}))"))
                Directory.CreateDirectory($"musics/{musicId}");

            var pathToWrite = $"musics/{musicId}.mp4";

            File.WriteAllBytes(pathToWrite, musicBytes);

            Directory.SetCurrentDirectory("/app");
            
            return new() { Id = musicId, Name = musicsInfos.Name, Description = musicsInfos.Description, MusicPath = pathToWrite };
        }
    }
}
