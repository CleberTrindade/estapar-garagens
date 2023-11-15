using Estapar.Garagens.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estapar.Garagens.Infrastructure.EntitiesConfiguration
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(t => t.Codigo);

            builder.Property(p => p.Descricao).HasMaxLength(50).IsRequired();
        }
    }
}
