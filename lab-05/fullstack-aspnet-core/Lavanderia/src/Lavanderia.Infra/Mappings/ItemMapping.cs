using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Valor)
                .IsRequired()
                .HasColumnType("decimal(15,5)");

            builder.ToTable("items");
        }
    }
}
