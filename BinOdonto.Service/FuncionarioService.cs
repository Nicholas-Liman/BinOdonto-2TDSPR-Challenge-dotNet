using Microsoft.EntityFrameworkCore;
using BinOdonto.Domain.Entities;
using BinOdonto.Application.Dtos;
using BinOdonto.Data.AppData;

namespace BinOdonto.Service
{
    public class FuncionarioService
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista todos os funcionários
        public async Task<IEnumerable<Funcionario>> GetFuncionariosAsync()
        {
            return await _context.Funcionario.ToListAsync();
        }

        // Busca funcionário por ID
        public async Task<Funcionario> GetFuncionarioByIdAsync(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                throw new KeyNotFoundException("Funcionário não encontrado.");
            }
            return funcionario;
        }

        // Adiciona novo funcionário
        public async Task<Funcionario> AddFuncionarioAsync(FuncionarioDTO funcionarioDTO)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    FuncionarioID = funcionarioDTO.FuncionarioID,
                    Nome = funcionarioDTO.Nome,
                    CPF = funcionarioDTO.CPF,
                    Cargo = funcionarioDTO.Cargo,
                    Salario = funcionarioDTO.Salario,
                    DataContratacao = funcionarioDTO.DataContratacao,
                    CEP = funcionarioDTO.CEP
                };
                _context.Funcionario.Add(funcionario);
                await _context.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar funcionário.", ex);
            }
        }

        // Atualiza dados de funcionário
        public async Task<Funcionario> UpdateFuncionarioAsync(int id, FuncionarioDTO funcionarioDTO)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null) return null;

            funcionario.Nome = funcionarioDTO.Nome;
            funcionario.CPF = funcionarioDTO.CPF;
            funcionario.Cargo = funcionarioDTO.Cargo;
            funcionario.Salario = funcionarioDTO.Salario;
            funcionario.DataContratacao = funcionarioDTO.DataContratacao;
            funcionario.CEP = funcionarioDTO.CEP;

            try
            {
                await _context.SaveChangesAsync();
                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar funcionário.", ex);
            }
        }

        // Deleta funcionário por ID
        public async Task<bool> DeleteFuncionarioAsync(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null) return false;

            try
            {
                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar funcionário.", ex);
            }
        }
    }
}
