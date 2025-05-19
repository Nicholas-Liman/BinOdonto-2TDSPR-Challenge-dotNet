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

        // Cadastra um novo funcionário com base nos dados do DTO
        public Funcionario? SalvarDadosFuncionario(FuncionarioDTO entity)
        {
            var funcionario = new Funcionario
            {
                Nome = entity.Nome,
                CPF = entity.CPF,
                Cargo = entity.Cargo,
                Salario = entity.Salario,
                DataContratacao = entity.DataContratacao,
                CEP = entity.CEP
            };

            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        // Edita os dados de um funcionário existente pelo ID
        public Funcionario? EditarDadosFuncionario(int id, FuncionarioEditDto entity)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null) return null;

            funcionario.Nome = entity.Nome;
            funcionario.CPF = entity.CPF;
            funcionario.Cargo = entity.Cargo;
            funcionario.Salario = entity.Salario;
            funcionario.DataContratacao = entity.DataContratacao;
            funcionario.CEP = entity.CEP;

            _context.SaveChanges();
            return funcionario;
        }

        // Remove um funcionário do banco de dados
        public Funcionario? DeletarDadosFuncionario(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null) return null;

            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        // Busca um funcionário por ID e retorna um DTO para exibição
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
                DataContratacao = funcionario.DataContratacao,
                CEP = funcionario.CEP
            };
        }

        // Retorna todos os funcionários convertidos em DTOs para exibição
        public IEnumerable<FuncionarioEditDto> ObterTodosFuncionarios()
        {
            return _context.Funcionario.Select(funcionario => new FuncionarioEditDto
            {
                FuncionarioID = funcionario.FuncionarioID,
                Nome = funcionario.Nome,
                CPF = funcionario.CPF,
                Cargo = funcionario.Cargo,
                Salario = funcionario.Salario,
                DataContratacao = funcionario.DataContratacao,
                CEP = funcionario.CEP
            }).ToList();
        }
    }
}
