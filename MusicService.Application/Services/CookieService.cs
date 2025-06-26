using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MusicService.Application.Interfaces;

namespace MusicService.Application.Services
{
    public class CookieService(
        IConfiguration configuration) : ICookieService
    {
        private readonly TimeSpan _expireAccess = DateTime.Now.AddDays(int.Parse(configuration["JwtSettings:AccessExpireDays"]!)) - DateTime.Now;

        public void AppendAccessTokenToCookie(HttpResponse response, string accessToken)
        {
            response.Cookies.Append("access", accessToken, new CookieOptions()
            {
                SameSite = SameSiteMode.Lax,
                Secure = true,
                HttpOnly = true,
                MaxAge = _expireAccess
            });
        }
    }
}
