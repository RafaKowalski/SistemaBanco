using SistemaBanco.Domain.BoletoModulo;
using SistemaBanco.Infra.Data.EF.Boletos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBanco.Application.BoletoServices
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletosRepository _boletosRepository;

        public BoletoService(IBoletosRepository boletosRepository)
        {
            _boletosRepository = boletosRepository;
        }

        public async Task<Boleto> AddBoletoAsync(Boleto boleto)
        {
            if (boleto.BoletoId == Guid.Empty)
            {
                throw new Exception("Id do boleto não pode ser vazio");
            }

            if (string.IsNullOrEmpty(boleto.NomeDoPagador))
            {
                throw new Exception("Nome do pagador não pode ser vazio");
            }

            if (string.IsNullOrEmpty(boleto.CpfDoPagador))
            {
                throw new Exception("CPF do pagador não pode ser vazio");
            }

            if (string.IsNullOrEmpty(boleto.NomeDoBeneficiario))
            {
                throw new Exception("Nome do beneficiario não pode ser vazio");
            }

            if (string.IsNullOrEmpty(boleto.CpfDoBeneficiario))
            {
                throw new Exception("Cpf do beneficiario não pode ser vazio");
            }

            if (boleto.Valor < 0)
            {
                throw new Exception("Valor deve ser maior que 0");
            }

            if (boleto.DataDeVencimento <= DateTime.Today)
            {
                throw new Exception("A data não pode ser menor do que o dia atual");
            }

            if (boleto.BancoId == Guid.Empty)
            {
                throw new Exception("Id do banco não pode ser vazio");
            }

            var addBoleto = await _boletosRepository.AddBoletoAsync(boleto);

            return addBoleto;
        }

        public async Task<Boleto> GetBoletoByIdAsync(Guid Id)
        {
            var getBoletoPorId = await _boletosRepository.GetBoletoByIdAsync(Id);


            if (DateTime.Now.Date > getBoletoPorId.DataDeVencimento)
            {
                var acrescimoDoValor = getBoletoPorId.Valor * (getBoletoPorId.Banco.PercentualDeJuros / 100);
                getBoletoPorId.Valor += acrescimoDoValor;
            }

            return getBoletoPorId;
        }
    }
}
