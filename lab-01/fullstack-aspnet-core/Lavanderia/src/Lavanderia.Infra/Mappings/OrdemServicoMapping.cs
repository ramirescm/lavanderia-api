using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Mappings
{
    public class OrdemServicoMapping : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataEntrada)
                .IsRequired();

            builder.Property(e => e.DataSaida)
               .IsRequired();

            builder.Property(e => e.DataEntrada)
               .IsRequired();

            builder.Property(e => e.ValorTotal)
               .IsRequired()
               .HasColumnType("decimal(15,5)");

            builder.HasOne(e => e.Cliente);

            builder.ToTable("ordems_servicos");
        }
    }
}
