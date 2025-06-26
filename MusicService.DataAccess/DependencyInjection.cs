using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicService.Application.Interfaces;
using MusicService.Database;

namespace MusicService.JwtProvider
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services
            , IConfiguration configuration)
        {
            var connectionString =
                configuration["DataAccess:ConnectionStringDefault"] ?? throw new ArgumentNullException(nameof(configuration), "ConnectionString is missing in configuration.");

            services.AddDbContext<MusicServiceContext>(opt =>
            {
                opt.UseNpgsql(connectionString, opt =>
                {
                    opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });
            });
            services.AddScoped<IMusicServiceContext, MusicServiceContext>();

            return services;
        }
    }
}
