using System.Collections.Generic;
using System.Linq;
using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using BinOdonto.Data.AppData;
using BinOdonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BinOdonto.Service
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Funcionario? SalvarDadosFuncionario(FuncionarioDTO entity)
        {
            var funcionario = new Funcionario
            {
                Nome = entity.Nome,
                CPF = entity.CPF,
                Cargo = entity.Cargo,
                Salario = entity.Salario,
                DataContratacao = entity.DataContratacao
            };

            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        public Funcionario? EditarDadosFuncionario(int id, FuncionarioEditDto entity)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null) return null;

            funcionario.Nome = entity.Nome;
            funcionario.CPF = entity.CPF;
            funcionario.Cargo = entity.Cargo;
            funcionario.Salario = entity.Salario;
            funcionario.DataContratacao = entity.DataContratacao;

            _context.SaveChanges();
            return funcionario;
        }

        public Funcionario? DeletarDadosFuncionario(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null) return null;

            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        public FuncionarioEditDto? ObterFuncionarioPorId(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null) return null;

            return new FuncionarioEditDto
            {
                FuncionarioID = funcionario.FuncionarioID,
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Cargo = funcionario.Cargo,
                Salario = funcionario.Salario,
                DataContratacao = funcionario.DataContratacao
            };
        }

        public IEnumerable<FuncionarioEditDto> ObterTodosFuncionarios()
        {
            return _context.Funcionario.Select(funcionario => new FuncionarioEditDto
            {
                FuncionarioID = funcionario.FuncionarioID,
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Cargo = funcionario.Cargo,
                Salario = funcionario.Salario,
                DataContratacao = funcionario.DataContratacao
            }).ToList();
        }
    }
}
