using SistemaBanco.Domain.BancoModulo;
using SistemaBanco.Infra.Data.EF.Bancos;

namespace SistemaBanco.Application.BancoServices
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public async Task<Banco> AddBancoAsync(Banco banco)
        {
            if (banco.BancoId == Guid.Empty)
            {
                throw new Exception("Id do banco não pode ser vazio");
            }

            if (string.IsNullOrEmpty(banco.NomeDoBanco))
            {
                throw new Exception("Nome do banco não pode ser vazio");
            }

            if (string.IsNullOrEmpty(banco.CodigoDoBanco))
            {
                throw new Exception("Codigo do banco não pode ser vazio");
            }

            if (banco.PercentualDeJuros < 0)
            {
                throw new Exception("Percentual de juros deve ser maior que 0 ");
            }

            var addBanco = await _bancoRepository.AddBancoAsync(banco);

            return addBanco;
        }

        public async Task<IEnumerable<Banco>> GetAllBancosAsync()
        {
            var todosBancos = await _bancoRepository.GetAllBancosAsync();

            if (string.IsNullOrEmpty(todosBancos.ToString()))
            {
                throw new Exception("Não possuí nenhum banco");
            }

            return todosBancos;
        }

        public async Task<Banco> GetBancoByIdAsync(Guid id)
        {
            var banco = await _bancoRepository.GetBancoByIdAsync(id);

            if (id == Guid.Empty)
            {
                throw new Exception("Id do banco vazio");
            }

            return banco;
        }
    }
}
