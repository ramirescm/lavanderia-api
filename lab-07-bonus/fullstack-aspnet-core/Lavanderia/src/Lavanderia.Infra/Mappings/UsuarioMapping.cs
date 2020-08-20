using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.ToTable("usuarios");
        }
    }
}
