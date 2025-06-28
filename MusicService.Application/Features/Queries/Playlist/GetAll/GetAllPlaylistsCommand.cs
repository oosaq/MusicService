using MediatR;
using MusicService.Application.Contracts.Dto.Playlist.GetAll;

namespace MusicService.Application.Features.Queries.Playlist.GetAll
{
    public record GetAllPlaylistsCommand : IRequest<List<GetAllPlaylistDto>>;
}
