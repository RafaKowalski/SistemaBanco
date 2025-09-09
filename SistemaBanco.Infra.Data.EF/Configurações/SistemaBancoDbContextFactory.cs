using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SistemaBanco.Infra.Data.EF.Configurações
{
    public class SistemaBancoDbContextFactory : IDesignTimeDbContextFactory<SistemaBancoDbContext>
    {
        public SistemaBancoDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "SistemaBanco");

            if (!Directory.Exists(basePath))
            {
                throw new Exception($"O diretório '{basePath}' não foi encontrado. Verifique o caminho.");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<SistemaBancoDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new SistemaBancoDbContext(optionsBuilder.Options);
        }
    }
}
