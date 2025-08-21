
using SimuladorCredito.Application.Profiles;

namespace SimuladorCredito.Api.Configuration
{
    public static class ProfilesConfiguration
    {
        public static IServiceCollection ConfigProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SimulationProfile).Assembly);

            return services;
        }
    }
}