using SistemaBanco.Domain.BoletoModulo;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaBanco.Domain.BancoModulo
{
    public class Banco
    {
        [Required]
        public Guid BancoId { get; set; }
        [Required]
        public string NomeDoBanco { get; set; }
        [Required]
        public string CodigoDoBanco { get; set; }
        [Required]
        public decimal PercentualDeJuros { get; set; }
        [JsonIgnore]
        public ICollection<Boleto>? Boletos { get; set; }
    }
}
