using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Common;
using MusicService.Domain.Common.Extensions;

namespace MusicService.Api.Extensions
{
    public static class ToActionResultSuccessTExtension
    {
        public static IActionResult ToActionResult<T>(this Success<T> success)
            => new ObjectResult(success.Data) { StatusCode = success.StatusCode.GetInt() };
    }
}
