using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Application.BoletoServices
{
    public interface IBoletoService
    {
        Task<Boleto> GetBoletoByIdAsync(Guid Id);
        Task<Boleto> AddBoletoAsync(Boleto boleto);
    }
}
