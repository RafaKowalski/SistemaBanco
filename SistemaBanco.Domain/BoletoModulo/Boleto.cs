using SistemaBanco.Domain.BancoModulo;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBanco.Domain.BoletoModulo
{
    public class Boleto
    {
        [Required]
        public Guid BoletoId { get; set; }
        [Required]
        public string NomeDoPagador { get; set; }
        [Required]
        public string CpfDoPagador { get; set; }
        [Required]
        public string NomeDoBeneficiario { get; set; }
        [Required]
        public string CpfDoBeneficiario { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataDeVencimento { get; set; }
        [Required]
        public string Observacao { get; set; }
        [JsonIgnore]
        public Banco? Banco { get; set; }
        [Required]
        public Guid BancoId { get; set; }

    }
}
