using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.Api.Extensions;
using MusicService.Application.Features.Commands.Albums.Add;
using MusicService.Application.Features.Commands.Genre.Add;
using MusicService.Application.Features.Queries.Album.GetAll;

namespace MusicService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class AlbumController(
        IMediator mediator) : ControllerBase
    {

        [HttpPut("add")]
        public async Task<IActionResult> AddGenre([FromBody] AddAlbumCommand request)
        {
            var result = await mediator.Send(request);

            return result.IsSuccess
                ? result.Success!.ToActionResult()
                : result.Error!.ToActionResult();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllAlbumQuery()));
        }
    }
}
