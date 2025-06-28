using MediatR;
using MusicService.Application.Contracts.Dto.Music.GetAll;

namespace MusicService.Application.Features.Queries.Musics.GetAllMusic
{
    public record GetAllMusicQuery : IRequest<List<GetAllMusicVm>>;
}
