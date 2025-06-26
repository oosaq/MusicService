using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Common;
using MusicService.Domain.Common.Extensions;

namespace MusicService.Api.Extensions
{
    public static class ToActionResultErrorExtension
    {
        public static IActionResult ToActionResult(this Error error)
            => new ObjectResult(error.ErrorMessage) { StatusCode = error.StatusCode.GetInt() };
    }
}
