using System.Collections.Generic;
using BinOdonto.Application.Dtos;
using BinOdonto.Domain.Entities;

namespace BinOdonto.Application.Interfaces
{
    public interface IFuncionarioApplicationService
    {
        Funcionario? SalvarDadosFuncionario(FuncionarioDTO entity);
        Funcionario? DeletarDadosFuncionario(int id);
        Funcionario? EditarDadosFuncionario(int id, FuncionarioEditDto entity);
        FuncionarioEditDto? ObterFuncionarioPorId(int id);
        IEnumerable<FuncionarioEditDto> ObterTodosFuncionarios();
    }
}
