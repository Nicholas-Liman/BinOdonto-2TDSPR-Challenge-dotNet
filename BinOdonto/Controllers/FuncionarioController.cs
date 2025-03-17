using Microsoft.AspNetCore.Mvc;
using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace BinOdonto.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApplicationService _funcionarioService;

        public FuncionarioController(IFuncionarioApplicationService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        // GET: api/funcionario
        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioEditDto>> GetAll()
        {
            var funcionarios = _funcionarioService.ObterTodosFuncionarios();
            return Ok(funcionarios);
        }

        // GET: api/funcionario/{FuncionarioID}
        [HttpGet("{FuncionarioID}")]
        public ActionResult<FuncionarioEditDto> GetById(int FuncionarioID)
        {
            var funcionario = _funcionarioService.ObterFuncionarioPorId(FuncionarioID);
            if (funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }

        // POST: api/funcionario
        [HttpPost]
        public ActionResult Create([FromBody] FuncionarioDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _funcionarioService.SalvarDadosFuncionario(model);
            return Ok(new { message = "Funcionário criado com sucesso!" });
        }



        // PUT: api/funcionario/{FuncionarioID}
        [HttpPut("{FuncionarioID}")]
        public ActionResult Edit(int FuncionarioID, [FromBody] FuncionarioEditDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionarioExistente = _funcionarioService.ObterFuncionarioPorId(FuncionarioID);
            if (funcionarioExistente == null)
                return NotFound();

            try
            {
                _funcionarioService.EditarDadosFuncionario(FuncionarioID, model);
                return Ok(new { message = "Funcionário atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/funcionario/{FuncionarioID}
        [HttpDelete("{FuncionarioID}")]
        public ActionResult Delete(int FuncionarioID)
        {
            var funcionario = _funcionarioService.ObterFuncionarioPorId(FuncionarioID);
            if (funcionario == null)
                return NotFound();

            try
            {
                _funcionarioService.DeletarDadosFuncionario(FuncionarioID);
                return Ok(new { message = "Funcionário excluído com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
