using Microsoft.EntityFrameworkCore;
using SistemaBanco.Domain.BancoModulo;
using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Infra.Data.EF.Configurações
{
    public class SistemaBancoDbContext : DbContext
    {
        public SistemaBancoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("O DbContext está sendo usado sem configuração.");
            }
        }
    }
}
