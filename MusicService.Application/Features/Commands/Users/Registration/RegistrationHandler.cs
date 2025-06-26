using BCrypt.Net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicService.Application.Interfaces;
using MusicService.Domain.Common;
using MusicService.Domain.Models;

namespace MusicService.Application.Features.Commands.Users.Registration
{
    public class RegistrationHandler(
        IMusicServiceContext context) : IRequestHandler<RegistrationCommand, Result<User>>
    {
        public async Task<Result<User>> Handle(RegistrationCommand request, CancellationToken ct)
        {
            var userFromDb = await context.Users.FirstOrDefaultAsync(u => u.NickName == request.NickName || u.Email == request.Email, ct);

            if (userFromDb?.NickName == request.NickName)
                return Result<User>.BadRequest("Имя пользователя уже занято");

            if (userFromDb?.Email == request.Email)
                return Result<User>.BadRequest("Почта уже занята");

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                NickName = request.NickName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await context.Users.AddAsync(user, ct);
            await context.SaveChangesAsync(ct);

            return Result<User>.Ok(user);
        }
    }
}
