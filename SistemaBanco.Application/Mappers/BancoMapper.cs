using AutoMapper;
using SistemaBanco.Application.BancoServices.DTO;
using SistemaBanco.Domain.BancoModulo;

namespace SistemaBanco.Application.Mappers
{
    public class BancoMapper: Profile
    {
        public BancoMapper()
        {
            CreateMap<BancoDTO, Banco>();
            CreateMap<Banco, BancoDTO>();
        }
    }
}
