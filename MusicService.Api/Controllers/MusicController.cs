using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicService.Api.Extensions;
using MusicService.Application.Features.Commands.Musics.AddMusic;
using MusicService.Application.Features.Commands.Musics.Delete;
using MusicService.Application.Features.Commands.Musics.Edit;
using MusicService.Application.Features.Queries.Musics.GetAllMusic;

namespace MusicService.Api.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class MusicController(
        IMediator mediator) : ControllerBase
    {

        [HttpPut("add")]
        public async Task<IActionResult> AddMusic([FromForm] AddMusicCommand request)
        {
            var result = await mediator.Send(request);

            return result.IsSuccess
                ? result.Success!.ToActionResult()
                : result.Error!.ToActionResult();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMusic([FromBody] DeleteMusicCommand request)
        {
            var result = await mediator.Send(request);

            return result.IsSuccess
                ? result.Success!.ToActionResult()
                : result.Error!.ToActionResult();
        }

        [HttpPatch("edit")]
        public async Task<IActionResult> Edit([FromBody] EditCommand request)
        {
            var result = await mediator.Send(request);

            return result.IsSuccess
                ? result.Success!.ToActionResult()
                : result.Error!.ToActionResult();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var musics = await mediator.Send(new GetAllMusicQuery());

            return Ok(musics);
        }
    }
}
