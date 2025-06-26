using Microsoft.AspNetCore.Http;

namespace MusicService.Application.Interfaces
{
    public interface ICookieService
    {
        void AppendAccessTokenToCookie(HttpResponse response, string accessToken);
    }
}
