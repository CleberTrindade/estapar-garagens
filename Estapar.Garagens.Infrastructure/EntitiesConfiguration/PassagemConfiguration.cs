using Estapar.Garagens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.Garagens.Infrastructure.EntitiesConfiguration
{
    public class PassagemConfiguration : IEntityTypeConfiguration<Passagem>
    {
        public void Configure(EntityTypeBuilder<Passagem> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(p => p.Garagem).HasMaxLength(20).IsRequired();
            builder.Property(p => p.CarroPlaca).HasMaxLength(20).IsRequired();
            builder.Property(p => p.CarroMarca).HasMaxLength(20).IsRequired();
            builder.Property(p => p.CarroModelo).HasMaxLength(20).IsRequired();
            builder.Property(p => p.DataHoraEntrada).IsRequired();
            builder.Property(p => p.DataHoraSaida);
            builder.Property(p => p.FormaPagamento).HasMaxLength(5);
            builder.Property(p => p.PrecoTotal).HasPrecision(10,2);

        }
    }
}
