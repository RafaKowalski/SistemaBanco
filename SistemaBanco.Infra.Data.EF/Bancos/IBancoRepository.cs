using SistemaBanco.Domain.BancoModulo;

namespace SistemaBanco.Infra.Data.EF.Bancos
{
    public interface IBancoRepository
    {
        Task<IEnumerable<Banco>> GetAllBancosAsync();
        Task<Banco> GetBancoByIdAsync(Guid id);
        Task<Banco> AddBancoAsync(Banco banco);
    }
}
