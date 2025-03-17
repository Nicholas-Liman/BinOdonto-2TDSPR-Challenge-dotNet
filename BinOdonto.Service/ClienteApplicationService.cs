using BinOdonto.Application.Interfaces;
using BinOdonto.Domain.Entities;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Application.Dtos;

namespace BinOdonto.Service
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplicationService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Deletar um Cliente por ID
        public Cliente? DeletarDadosCliente(int id)
        {
            return _clienteRepository.DeletarDados(id);
        }

        // Editar um Cliente existente
        public Cliente? EditarDadosCliente(int id, ClienteDTO entity)
        {
            var cliente = new Cliente
            {
                ClienteID = id,
                Nome = entity.Nome,
                CPF = entity.CPF,  // Incluindo CPF conforme sua implementação
                DataNascimento = entity.DataNascimento,  // Mantendo DataNascimento, caso seja necessário
                Email = entity.Email
            };

            return _clienteRepository.EditarDados(cliente);
        }

        // Obter Cliente por ID
        public Cliente? ObterClientePorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        // Obter todos os Clientes
        public IEnumerable<Cliente>? ObterTodosClientes()
        {
            return _clienteRepository.ObterTodos() ?? Enumerable.Empty<Cliente>();
        }

        // Salvar um novo Cliente
        public Cliente? SalvarDadosCliente(ClienteDTO entity)
        {
            // Criar cliente e salvar no repositório
            var cliente = new Cliente
            {
                Nome = entity.Nome,
                CPF = entity.CPF,
                DataNascimento = entity.DataNascimento,
                Email = entity.Email,
            };

            return _clienteRepository.SalvarDados(cliente);
        }
    }
}
