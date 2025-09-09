using AutoMapper;
using SistemaBanco.Application.BoletoServices.DTO;
using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Application.Mappers
{
    public class BoletoMapper : Profile
    {
        public BoletoMapper()
        {
            CreateMap<BoletoDTO, Boleto>();
            CreateMap<Boleto, BoletoDTO>();
        }
    }
}
