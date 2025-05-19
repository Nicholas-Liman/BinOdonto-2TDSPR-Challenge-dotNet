using Microsoft.AspNetCore.Mvc;
using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
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

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os funcionários", Description = "Retorna todos os funcionários cadastrados.")]
        public ActionResult<IEnumerable<FuncionarioEditDto>> GetAll()
        {
            var funcionarios = _funcionarioService.ObterTodosFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{FuncionarioID}")]
        [SwaggerOperation(Summary = "Busca funcionário por ID", Description = "Retorna os dados de um funcionário específico.")]
        public ActionResult<FuncionarioEditDto> GetById(int FuncionarioID)
        {
            var funcionario = _funcionarioService.ObterFuncionarioPorId(FuncionarioID);
            if (funcionario == null)
                return NotFound();

            return Ok(funcionario);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo funcionário", Description = "Cadastra um novo funcionário, incluindo o campo CEP.")]
        public ActionResult Create([FromBody] FuncionarioDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _funcionarioService.SalvarDadosFuncionario(model);
            return Ok(new { message = "Funcionário criado com sucesso!" });
        }

        [HttpPut("{FuncionarioID}")]
        [SwaggerOperation(Summary = "Atualiza um funcionário", Description = "Edita os dados de um funcionário, incluindo o campo CEP.")]
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

        [HttpDelete("{FuncionarioID}")]
        [SwaggerOperation(Summary = "Exclui um funcionário", Description = "Remove um funcionário do sistema.")]
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
