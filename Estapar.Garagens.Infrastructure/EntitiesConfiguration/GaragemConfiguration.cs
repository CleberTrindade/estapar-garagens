using Estapar.Garagens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.Garagens.Infrastructure.EntitiesConfiguration
{
    public class GaragemConfiguration : IEntityTypeConfiguration<Garagem>
    {
        public void Configure(EntityTypeBuilder<Garagem> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco_1aHora).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Preco_HorasExtra).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Preco_Mensalista).HasPrecision(10, 2).IsRequired();
        }
    }
}
