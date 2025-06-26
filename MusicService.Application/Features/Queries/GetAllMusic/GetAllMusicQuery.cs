using MediatR;
using MusicService.Application.Contracts.Dto.Music.GetAll;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Queries.GetAll
{
    public record GetAllMusicQuery : IRequest<List<MusicVm>>;
}
