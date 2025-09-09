using Microsoft.EntityFrameworkCore;
using SistemaBanco.Domain.BoletoModulo;
using SistemaBanco.Infra.Data.EF.Configurações;

namespace SistemaBanco.Infra.Data.EF.Boletos
{
    public class BoletoRepository : IBoletosRepository
    {
        private readonly SistemaBancoDbContext _context;

        public BoletoRepository(SistemaBancoDbContext context)
        {
            _context = context;
        }

        public async Task<Boleto> AddBoletoAsync(Boleto boleto)
        {
            var novoBoleto = _context.Boletos.Add(boleto).Entity;
            await _context.SaveChangesAsync();

            return novoBoleto;
        }

        public async Task<Boleto> GetBoletoByIdAsync(Guid Id)
        {
            return await _context.Boletos.Include(b => b.Banco).FirstOrDefaultAsync(b => b.BoletoId == Id);
        }
    }
}
