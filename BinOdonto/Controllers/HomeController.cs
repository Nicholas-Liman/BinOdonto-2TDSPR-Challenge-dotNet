using Microsoft.AspNetCore.Mvc;

namespace BinOdonto.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
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
    }
}
