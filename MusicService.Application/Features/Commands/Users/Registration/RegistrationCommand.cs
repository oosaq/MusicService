using MediatR;
using MusicService.Domain.Common;
using MusicService.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicService.Application.Features.Commands.Users.Registration
{
    public class RegistrationCommand : IRequest<Result<User>>
    {
        [Required(ErrorMessage = "Имя пользователя не может быть пустым")]
        [Length(4, 25, ErrorMessage = "Имя пользователя должно быть не менее 4 и не более 25 символов")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Почта не может быть пустым")]
        [EmailAddress(ErrorMessage = "Неверный тип почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не может быть пустым")]
        [Length(4, 25, ErrorMessage = "Пароль должен быть не менее 4 и не более 25 символов")]
        public string Password { get; set; }
    }
}
