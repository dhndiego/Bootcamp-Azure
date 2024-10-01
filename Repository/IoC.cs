using Domain.Interfaces.Repository.Base;
using Microsoft.Extensions.DependencyInjection;
using Repository.Bootcamp;

namespace Repository
{
    public static class IoC
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkBootcamp, UnitOfWorkBootcamp>();
           
            return services;
        }
    }
}
