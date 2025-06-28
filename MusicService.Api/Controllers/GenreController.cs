using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.Api.Extensions;
using MusicService.Application.Features.Commands.Genre.Add;

namespace MusicService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class GenreController(
        IMediator mediator) : ControllerBase
    {
        [HttpPut("add")]
        public async Task<IActionResult> AddGenre([FromForm] AddGenreCommand request)
        {
            var result = await mediator.Send(request);

            return result.IsSuccess
                ? result.Success!.ToActionResult()
                : result.Error!.ToActionResult();
        }
    }
}
