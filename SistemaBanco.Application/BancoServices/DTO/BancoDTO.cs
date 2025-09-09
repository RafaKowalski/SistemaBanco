using SistemaBanco.Domain.BoletoModulo;
using System.Text.Json.Serialization;

namespace SistemaBanco.Application.BancoServices.DTO
{
    public class BancoDTO
    {
        public Guid BancoId { get; set; }
        public string NomeDoBanco { get; set; }
        public string CodigoDoBanco { get; set; }
        public decimal PercentualDeJuros { get; set; }
        [JsonIgnore]
        public ICollection<Boleto>? Boletos { get; set; }
    }
}
