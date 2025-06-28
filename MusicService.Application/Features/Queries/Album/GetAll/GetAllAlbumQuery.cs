using MediatR;
using MusicService.Application.Contracts.Dto.Album.GetAll;

namespace MusicService.Application.Features.Queries.Album.GetAll
{
    public class GetAllAlbumQuery : IRequest<List<GetAllAlbumDto>>
    {
    }
}
