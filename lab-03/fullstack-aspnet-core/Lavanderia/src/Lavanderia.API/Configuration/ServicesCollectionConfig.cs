using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Infra.Context;
using Lavanderia.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lavanderia.API.Configuration
{
    public static class ServicesCollectionConfig
    {
        public static IServiceCollection ResolveConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LavanderiaContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<LavanderiaContext>();

            services.AddTransient<IClienteRepository, ClienteRepository>();


            return services;
        }
    }
}
