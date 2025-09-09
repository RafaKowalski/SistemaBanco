using Microsoft.EntityFrameworkCore;
using SistemaBanco.Domain.BancoModulo;
using SistemaBanco.Infra.Data.EF.Configurações;

namespace SistemaBanco.Infra.Data.EF.Bancos
{
    public class BancoRepository : IBancoRepository
    {
        private readonly SistemaBancoDbContext _context;

        public BancoRepository(SistemaBancoDbContext context)
        {
            _context = context;
        }

        public async Task<Banco> AddBancoAsync(Banco banco)
        {
            var novoBanco = _context.Bancos.Add(banco).Entity;
            await _context.SaveChangesAsync();

            return novoBanco;
        }

        public async Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<Banco> GetBancoByIdAsync(Guid id)
        {
            return await _context.Bancos.FindAsync(id);
        }
    }
}
