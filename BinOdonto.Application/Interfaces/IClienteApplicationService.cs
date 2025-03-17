using System.Collections.Generic;
using BinOdonto.Application.Dtos;
using BinOdonto.Domain.Entities;

namespace BinOdonto.Application.Interfaces
{
    public interface IClienteApplicationService
    {
        IEnumerable<Cliente>? ObterTodosClientes();
        Cliente? ObterClientePorId(int id);
        Cliente? SalvarDadosCliente(ClienteDTO entity);
        Cliente? EditarDadosCliente(int id, ClienteDTO entity);
        Cliente? DeletarDadosCliente(int id);
    }
}
