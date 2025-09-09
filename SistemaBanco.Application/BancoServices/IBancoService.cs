using SistemaBanco.Domain.BancoModulo;

namespace SistemaBanco.Application.BancoServices
{
    public interface IBancoService
    {
        Task<IEnumerable<Banco>> GetAllBancosAsync();
        Task<Banco> GetBancoByIdAsync(Guid id);
        Task<Banco> AddBancoAsync(Banco banco);
    }
}
