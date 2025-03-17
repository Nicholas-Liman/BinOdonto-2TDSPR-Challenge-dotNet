using Microsoft.AspNetCore.Mvc;
using BinOdonto.Application.Interfaces;

namespace BinOdonto.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguracaoService _configuracaoService;

        public HomeController(IConfiguracaoService configuracaoService)
        {
            _configuracaoService = configuracaoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "API BinOdonto rodando com sucesso!" });
        }

        [HttpGet("cliente")]
        public IActionResult ClienteIndex()
        {
            return Ok(new { message = "Página do Cliente (Placeholder)" });
        }

        [HttpGet("funcionario")]
        public IActionResult FuncionarioIndex()
        {
            return Ok(new { message = "Página do Funcionário (Placeholder)" });
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return Ok(new { message = "Política de Privacidade (Placeholder)" });
        }

        // Novo endpoint para testar o Singleton
        [HttpGet("configuracao/{chave}")]
        public IActionResult GetConfiguracao(string chave)
        {
            var valor = _configuracaoService.GetConfiguracao(chave);
            return Ok(new { chave, valor });
        }
    }
}
