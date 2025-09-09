using SistemaBanco.Domain.BancoModulo;
using System.Text.Json.Serialization;

namespace SistemaBanco.Application.BoletoServices.DTO
{
    public class BoletoDTO
    {
        public Guid BoletoId { get; set; }
        public string NomeDoPagador { get; set; }
        public string CpfDoPagador { get; set; }
        public string NomeDoBeneficiario { get; set; }
        public string CpfDoBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public string Observacao { get; set; }
        [JsonIgnore]
        public Banco? Banco { get; set; }
        public Guid BancoId { get; set; }
    }
}
