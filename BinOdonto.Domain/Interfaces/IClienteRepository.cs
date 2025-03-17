using System.Collections.Generic;
using BinOdonto.Domain.Entities;

namespace BinOdonto.Domain.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente>? ObterTodos();
        Cliente? ObterPorId(int id);
        Cliente? SalvarDados(Cliente entity);
        Cliente? EditarDados(Cliente entity);
        Cliente? DeletarDados(int id);
    }
}
