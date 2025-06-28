using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MusicService.Application.Services
{
    public class CurrentUserService(IHttpContextAccessor contextAccessor)
    {

        public Guid UserId
        {
            get
            {
                var userIdClaim = contextAccessor.HttpContext.User.FindFirst("UserId")?.Value;

                return userIdClaim != null && Guid.TryParse(userIdClaim, out var id)
                    ? id
                    : Guid.Empty;
            }
        }
        public string Email
        {
            get
            {
                var userEmailClaim = contextAccessor.HttpContext.User.FindFirst("UserEmail")?.Value;

                return userEmailClaim != null
                ? userEmailClaim
                    : string.Empty;
            }
        }
    }
}
