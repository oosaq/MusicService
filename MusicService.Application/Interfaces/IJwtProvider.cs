using MusicService.Domain.Models;

namespace MusicService.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(User user);
    }
}
