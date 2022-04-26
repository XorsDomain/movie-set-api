using Catalyte.Theater.Providers.Interfaces;
using Catalyte.Theater.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Theater.Providers
{
    /// <summary>
    /// This class provides configuration options for provider services.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IMovieProvider, MovieProvider>();
            services.AddScoped<IRentalProvider, RentalProvider>();

            return services;
        }
    }
}
