using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LavanderiaContext).Assembly);
            HandleNames(modelBuilder);

            // se apagar o pai se o id do pai no filho pra null
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }

        private void HandleNames(ModelBuilder modelBuilder)
        {
            string toSnakeCase(string name)
                => Regex
                    .Replace(
                        name,
                        @"([a-z0-9])([A-Z])",
                        "$1_$2",
                        RegexOptions.Compiled)
                    .ToLower();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = toSnakeCase(entity.GetTableName());
                entity.SetTableName(tableName);

                foreach (var property in entity.GetProperties())
                {
                    var columnName = toSnakeCase(property.GetColumnName());
                    property.SetColumnName(columnName);
                }

                foreach (var key in entity.GetKeys())
                {
                    var keyName = toSnakeCase(key.GetName());
                    key.SetName(keyName);
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    var foreignKeyName = toSnakeCase(key.GetConstraintName());
                    key.SetConstraintName(foreignKeyName);
                }

                foreach (var index in entity.GetIndexes())
                {
                    var indexName = toSnakeCase(index.GetName());
                    index.SetName(indexName);
                }
            }
        }
    }
}
