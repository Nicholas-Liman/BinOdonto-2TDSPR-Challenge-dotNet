using System.Collections.Generic;
using BinOdonto.Domain.Entities;

namespace BinOdonto.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        IEnumerable<Funcionario>? ObterTodos();
        Funcionario? ObterPorId(int id);
        Funcionario? SalvarDados(Funcionario entity);
        Funcionario? EditarDados(Funcionario entity);
        Funcionario? DeletarDados(int id);
    }
}
