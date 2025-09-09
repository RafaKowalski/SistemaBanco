using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Infra.Data.EF.Boletos
{
    public class BoletoEntityConfiguration : IEntityTypeConfiguration<Boleto>
    {
        public void Configure (EntityTypeBuilder<Boleto> builder)
        {
            builder.ToTable("Boletos");

            builder.HasKey(b => b.BoletoId);

            builder.Property(b => b.BoletoId).IsRequired();
            builder.Property(b => b.NomeDoPagador).IsRequired().HasMaxLength(100);
            builder.Property(b => b.CpfDoPagador).IsRequired().HasMaxLength(100);
            builder.Property(b => b.NomeDoBeneficiario).IsRequired().HasMaxLength(100);
            builder.Property(b => b.CpfDoBeneficiario).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Valor).IsRequired().HasMaxLength(100);
            builder.Property(b => b.DataDeVencimento).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Observacao).IsRequired().HasMaxLength(100);

            builder.HasOne(b => b.Banco).WithMany(a => a.Boletos).HasForeignKey(b => b.BancoId);
        }
    }
}
