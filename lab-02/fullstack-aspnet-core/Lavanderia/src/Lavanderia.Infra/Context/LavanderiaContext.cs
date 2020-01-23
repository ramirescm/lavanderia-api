using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Context
{
    public class LavanderiaContext : DbContext
    {
        public LavanderiaContext(DbContextOptions<LavanderiaContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LavanderiaContext).Assembly);

            // se apagar o pai se o id do pai no filho pra null
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //base.OnModelCreating(modelBuilder);

            //modelBuilder.ToSnakeNames();
        }

    }
}
