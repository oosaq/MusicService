using MusicService.Application.Features.Commands.Musics.AddMusic;
using MusicService.Domain.Models;

namespace MusicService.Application.Interfaces
{
    public interface IMusicService
    {

        Task<Music> WriteMusicFileAndReturnAsync(AddMusicCommand musicsInfos, CancellationToken ct);
    }
}
