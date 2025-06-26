using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicService.Api.Extensions;
using MusicService.Application.Features.Commands.Users.Login;
using MusicService.Application.Features.Commands.Users.Registration;
using MusicService.Application.Interfaces;

namespace MusicService.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController(
        IMediator mediator,
        ICookieService cookieService,
        IJwtProvider jwtProvider) : ControllerBase
    {

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(RegistrationCommand request)
        {
            var result = await mediator.Send(request);

            if (!result.IsSuccess)
                return result.Error!.ToActionResult();

            cookieService.AppendAccessTokenToCookie(Response, jwtProvider.GenerateAccessToken(result.Success!.Data));

            return Created();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var result = await mediator.Send(request);

            if (!result.IsSuccess)
                return result.Error!.ToActionResult();

            cookieService.AppendAccessTokenToCookie(Response, jwtProvider.GenerateAccessToken(result.Success!.Data));

            return Ok();
        }
    }
}
