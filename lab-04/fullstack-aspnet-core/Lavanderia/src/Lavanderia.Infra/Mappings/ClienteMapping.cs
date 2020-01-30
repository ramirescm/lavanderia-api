using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);

            //builder.Property(e => e.Id)
            //    .UseIdentityByDefaultColumn();

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(80)");

            builder.Property(e => e.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(120)");

            builder.ToTable("clientes");
        }
    }
}
