using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Users.Login
{
    public class LoginHandler(
        IMusicServiceContext context) : IRequestHandler<LoginCommand, Result<User>>
    {
        public async Task<Result<User>> Handle(LoginCommand request, CancellationToken ct)
        {
            var userFromDb = await context.Users.FirstOrDefaultAsync(u => u.NickName == request.NickName, ct);

            if (userFromDb == null)
                return Result<User>.BadRequest("Пользователь не найден");
            if (!BCrypt.Net.BCrypt.Verify(request.Password, userFromDb.Password))
                return Result<User>.BadRequest("Неверный пароль");

            return Result<User>.Ok(userFromDb);
        }
    }
}
