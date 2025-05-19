using Microsoft.AspNetCore.Mvc;
using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

namespace BinOdonto.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteService;

        public ClienteController(IClienteApplicationService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os clientes", Description = "Retorna todos os clientes cadastrados.")]
        public ActionResult<IEnumerable<ClienteEditDto>> GetAll()
        {
            var clientes = _clienteService.ObterTodosClientes();

            var clienteDtos = clientes.Select(cliente => new ClienteEditDto
            {
                ClienteID = cliente.ClienteID,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Email = cliente.Email,
                CEP = cliente.CEP
            }).ToList();

            return Ok(clienteDtos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca cliente por ID", Description = "Retorna os dados de um cliente específico.")]
        public ActionResult<ClienteEditDto> GetById(int id)
        {
            var cliente = _clienteService.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();

            var clienteDto = new ClienteEditDto
            {
                ClienteID = cliente.ClienteID,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Email = cliente.Email,
                CEP = cliente.CEP
            };

            return Ok(clienteDto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo cliente", Description = "Cadastra um novo cliente com base nos dados fornecidos, incluindo CEP.")]
        public ActionResult Create([FromBody] ClienteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _clienteService.SalvarDadosCliente(model);
            return Ok(new { message = "Cliente criado com sucesso!" });
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um cliente", Description = "Edita os dados de um cliente, incluindo CEP.")]
        public ActionResult Edit(int id, [FromBody] ClienteEditDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteExistente = _clienteService.ObterClientePorId(id);
            if (clienteExistente == null)
                return NotFound();

            _clienteService.EditarDadosCliente(id, model);
            return Ok(new { message = "Cliente atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um cliente", Description = "Remove um cliente do sistema.")]
        public ActionResult Delete(int id)
        {
            var cliente = _clienteService.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();

            _clienteService.DeletarDadosCliente(id);
            return Ok(new { message = "Cliente excluído com sucesso!" });
        }
    }
}
