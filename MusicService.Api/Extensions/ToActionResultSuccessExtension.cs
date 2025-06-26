using Microsoft.AspNetCore.Mvc;
using MusicService.Domain.Common;
using MusicService.Domain.Common.Extensions;

namespace MusicService.Api.Extensions
{
    public static class ToActionResultSuccessExtension
    {
        public static IActionResult ToActionResult(this Success success)
            => new StatusCodeResult(success.StatusCode.GetInt());
    }
}
