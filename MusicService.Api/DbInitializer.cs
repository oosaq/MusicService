using MusicService.Database;

namespace KartoshkaEvent.Api
{
    public class DbInitializer
    {
        public static async Task Initialize(MusicServiceContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
