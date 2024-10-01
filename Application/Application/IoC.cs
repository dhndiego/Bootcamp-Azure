using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAzureService, AzureService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IExperienceService, ExperienceService>();

            return services;
        }

    }
}
