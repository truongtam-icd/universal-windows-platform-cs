using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Migration.PostgreSQL;

namespace Migration
{
    internal class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UWPContext>(options =>
            {
                options.UseNpgsql(UWPContext.GetConfigDB());
            });
        }
    }
}
