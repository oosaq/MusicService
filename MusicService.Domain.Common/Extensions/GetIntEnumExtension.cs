using System.Net;

namespace MusicService.Domain.Common.Extensions
{
    public static class GetIntEnumExtension
    {
        public static int GetInt(this HttpStatusCode statusCode)
        {
            return (int)statusCode;
        }
    }
}
