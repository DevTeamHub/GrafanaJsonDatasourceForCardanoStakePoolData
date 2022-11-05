using GrafanaJsonWebApiCardanoPool.Services.Implementations;
using GrafanaJsonWebApiCardanoPool.Services.Interfaces;
using GrafanaJsonWebApiCardanoPool.Settings;

namespace GrafanaJsonWebApiCardanoPool.Configuration
{
    public class DiContainerConfig
    {
        public static void ConfigureCoreAppContainer(IServiceCollection services)
        {
            services.AddTransient<IPoolDataService, PoolDataService>();

            services.AddHttpClient<IPoolDataService, PoolDataService>();
        }

        public static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

        }
    }
}
