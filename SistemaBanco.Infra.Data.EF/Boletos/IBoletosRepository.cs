using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Infra.Data.EF.Boletos
{
    public interface IBoletosRepository
    {
        Task<Boleto> GetBoletoByIdAsync(Guid Id);
        Task<Boleto> AddBoletoAsync(Boleto boleto);
    }
}
