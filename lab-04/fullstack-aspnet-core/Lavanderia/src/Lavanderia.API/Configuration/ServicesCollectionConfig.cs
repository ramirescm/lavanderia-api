using Lavanderia.Application.Interfaces;
using Lavanderia.Application.Services;
using Lavanderia.Domain.Interfaces.Repository;
using Lavanderia.Domain.Interfaces.UoW;
using Lavanderia.Domain.Notificacoes;
using Lavanderia.Infra.Context;
using Lavanderia.Infra.Repository;
using Lavanderia.Infra.UoW;
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
            services.AddScoped<LavanderiaContext>(); // vantagens e desvantagens de usar como escoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IItemOrdemRepository, ItemOrdemRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrdemServicoRepository, OrdemServicoRepository>();

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrdemServicoService, OrdemServicoService>();

            services.AddScoped<INotificador, Notificador>();


            return services;
        }
    }
}
