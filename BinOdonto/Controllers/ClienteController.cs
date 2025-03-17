using Microsoft.AspNetCore.Mvc;
using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using System.Linq;
using System.Collections.Generic;

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

        // GET: api/cliente
        [HttpGet]
        public ActionResult<IEnumerable<ClienteEditDto>> GetAll()
        {
            var clientes = _clienteService.ObterTodosClientes();

            var clienteDtos = clientes.Select(cliente => new ClienteEditDto
            {
                ClienteID = cliente.ClienteID,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                Email = cliente.Email
            }).ToList();

            return Ok(clienteDtos);
        }

        // GET: api/cliente/{id}
        [HttpGet("{id}")]
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
                Email = cliente.Email
            };

            return Ok(clienteDto);
        }

        // POST: api/cliente
        [HttpPost]
        public ActionResult Create([FromBody] ClienteDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _clienteService.SalvarDadosCliente(model);
            return Ok(new { message = "Cliente criado com sucesso!" });
        }

        // PUT: api/cliente/{id}
        [HttpPut("{id}")]
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

        // DELETE: api/cliente/{id}
        [HttpDelete("{id}")]
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
