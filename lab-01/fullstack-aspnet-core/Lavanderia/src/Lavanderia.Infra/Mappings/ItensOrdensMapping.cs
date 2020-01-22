using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Mappings
{
    public class ItensOrdensMapping : IEntityTypeConfiguration<ItensOrdens>
    {
        public void Configure(EntityTypeBuilder<ItensOrdens> builder)
        {
            builder.HasKey(e => new { e.ItemId, e.OrdemId });

            builder.HasOne(e => e.Item)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.ItemId);

            builder.HasOne(e => e.OrdemServico)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.OrdemId);

            builder.ToTable("itens_ordem");
        }
    }
}
