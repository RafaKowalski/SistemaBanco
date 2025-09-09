using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaBanco.Application.BancoServices;
using SistemaBanco.Application.BancoServices.DTO;
using SistemaBanco.Domain.BancoModulo;

namespace SistemaBanco.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        private readonly IMapper _mapper;

        public BancosController(IBancoService bancoService, IMapper mapper)
        {
            _bancoService = bancoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os bancos cadastrados
        /// </summary>
        /// <returns>Lista de bancos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BancoDTO>>> GetAllBancos()
        {
            return Ok(await _bancoService.GetAllBancosAsync());
        }

        /// <summary>
        /// Retorna um banco pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Banco específico pelo Id</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BancoDTO>> GetBancoById(Guid id)
        {
            return Ok(await _bancoService.GetBancoByIdAsync(id));
        }

        /// <summary>
        /// Cadastra um novo banco
        /// </summary>
        /// <param name="bancoDto"></param>
        /// <returns>Banco criado no banco de dados</returns>
        [HttpPost]
        public async Task<ActionResult<BancoDTO>> AddBanco(BancoDTO bancoDto)
        {
            var banco = _mapper.Map<Banco>(bancoDto);

            await _bancoService.AddBancoAsync(banco);

            var bancoResponse = _mapper.Map<BancoDTO>(banco);

            return Created($"/api/bancos/{bancoResponse.BancoId = Guid.NewGuid()}", bancoResponse);
        }
    }
}
