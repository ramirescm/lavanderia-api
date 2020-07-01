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
        public static IServiceCollection ConfigureConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LavanderiaContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        // DESAFIO mover as injecoes para suas camadas ex.:
        // Injecao de dependencia dos repository deve estar em Lavanderia.Infra
        // Injecao de dependencia dos services deve estar em Lavanderia.Application
        // E assim sucessivamente
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<LavanderiaContext>(); // vantagens e desvantagens de usar como escoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IItemOrdemRepository, ItemOrdemRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IOrdemServicoService, OrdemServicoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddScoped<INotificador, Notificador>();


            return services;
        }
    }
}
