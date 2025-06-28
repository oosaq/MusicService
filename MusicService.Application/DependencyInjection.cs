using Microsoft.Extensions.DependencyInjection;
using MusicService.Application.Interfaces;
using MusicService.Application.Services;
using System.Reflection;

namespace KartoshkaEvent.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(conf
                => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services
                .AddScoped<ICookieService, CookieService>()
                .AddScoped<IMusicService, MusicService.Application.Services.MusicService>()
                .AddScoped<CurrentUserService>();

            return services;
        }

    }
}
