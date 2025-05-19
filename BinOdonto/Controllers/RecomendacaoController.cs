using Microsoft.AspNetCore.Mvc;
using BinOdonto.Service;
using BinOdonto.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace BinOdonto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecomendacaoController : ControllerBase
    {
        private readonly FuncionarioRecomendadoService _recomendador;

        public RecomendacaoController(FuncionarioRecomendadoService recomendador)
        {
            _recomendador = recomendador;
        }

        [HttpGet("funcionario")]
        [SwaggerOperation(Summary = "Recomenda funcionário", Description = "Retorna o funcionário mais próximo com base no CEP")]
        public async Task<ActionResult<Funcionario>> GetFuncionarioMaisProximo([FromQuery] string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return BadRequest("O CEP é obrigatório.");

            var funcionario = await _recomendador.ObterMaisProximo(cep);

            if (funcionario == null)
                return NotFound("Nenhum funcionário encontrado para a localidade.");

            return Ok(funcionario);
        }
    }
}
