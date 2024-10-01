using Domain.Interfaces.Interfaces;
using Infrastructure.AzureServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IServiceBus, ServiceBus>();
            services.AddSingleton<IAzureOpenAI, AzureOpenAI>();

            return services;
        }        
    }
}
