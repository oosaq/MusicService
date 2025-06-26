using MediatR;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Users.Login
{
    public class LoginCommand : IRequest<Result<User>>
    {
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}
