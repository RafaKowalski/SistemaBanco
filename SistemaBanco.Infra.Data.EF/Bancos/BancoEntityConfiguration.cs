using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBanco.Domain.BancoModulo;
using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Infra.Data.EF.Bancos
{
    public class BancoEntityConfiguration : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("Bancos");

            builder.HasKey(b => b.BancoId);

            builder.Property(b => b.BancoId).IsRequired();
            builder.Property(b => b.NomeDoBanco).IsRequired().HasMaxLength(100);
            builder.Property(b => b.CodigoDoBanco).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PercentualDeJuros).IsRequired();

        }
    }
}
