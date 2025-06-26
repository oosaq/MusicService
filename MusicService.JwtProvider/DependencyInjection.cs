using Microsoft.Extensions.DependencyInjection;
using MusicService.Application.Interfaces;

namespace MusicService.JwtProvider
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJwtProvider(this IServiceCollection services)
        {

            services.AddTransient<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}
