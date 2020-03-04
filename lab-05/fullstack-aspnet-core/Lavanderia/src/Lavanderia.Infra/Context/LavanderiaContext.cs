using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Context
{
    public class LavanderiaContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        //public LavanderiaContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public LavanderiaContext(DbContextOptions<LavanderiaContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LavanderiaContext).Assembly);

            // se apagar o pai se o id do pai no filho pra null
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            //base.OnModelCreating(modelBuilder);

            //modelBuilder.ToSnakeNames();
        }


        //https://gunnarpeipman.com/ef-core-repository-unit-of-work/
        //private IDbContextTransaction _transaction;

        //public void BeginTransaction()
        //{
        //    _transaction = Database.BeginTransaction();
        //}

        //public void Commit()
        //{
        //    try
        //    {
        //        SaveChanges();
        //        _transaction.Commit();
        //    }
        //    finally
        //    {
        //        _transaction.Dispose();
        //    }
        //}

        //public void Rollback()
        //{
        //    _transaction.Rollback();
        //    _transaction.Dispose();
        //}

    }
}
