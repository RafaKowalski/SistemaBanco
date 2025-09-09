using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBanco.Application.BancoServices;
using SistemaBanco.Application.BancoServices.DTO;
using SistemaBanco.Application.BoletoServices;
using SistemaBanco.Application.BoletoServices.DTO;
using SistemaBanco.Domain.BancoModulo;
using SistemaBanco.Domain.BoletoModulo;

namespace SistemaBanco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletosController : ControllerBase
    {
        private readonly IBoletoService _boletoService;
        private readonly IMapper _mapper;

        public BoletosController(IBoletoService boletoService, IMapper mapper)
        {
            _boletoService = boletoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna um boleto pelo seu Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Boleto especificado pelo seu Id</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BoletoDTO>> GetBoletoById(Guid id)
        {
            return Ok(await _boletoService.GetBoletoByIdAsync(id));
        }

        /// <summary>
        /// Cadastrar um novo boleto
        /// </summary>
        /// <param name="boletoDto"></param>
        /// <returns> Cria um novo boleto no banco de dados</returns>
        [HttpPost]
        public async Task<ActionResult<BoletoDTO>> AddBoleto(BoletoDTO boletoDto)
        {
            var boleto = _mapper.Map<Boleto>(boletoDto);

            await _boletoService.AddBoletoAsync(boleto);

            var boletoResponse = _mapper.Map<BoletoDTO>(boleto);

            return Created($"/api/boletos/{boletoResponse.BoletoId = Guid.NewGuid()}", boletoResponse);
        }
    }
}
