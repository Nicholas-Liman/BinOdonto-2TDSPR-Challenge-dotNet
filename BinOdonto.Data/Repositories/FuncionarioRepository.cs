using BinOdonto.Domain.Entities;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Data.AppData;

namespace BinOdonto.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Salvar um novo Funcionário
        public Funcionario? SalvarDados(Funcionario entity)
        {
            try
            {
                _context.Funcionario.Add(entity);
                _context.SaveChanges(); // Importante: garantir que as mudanças são persistidas
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar o funcionário.", ex);
            }
        }

        // Método para verificar se o CPF já existe
        public bool CpfExiste(string cpf)
        {
            return _context.Funcionario.Any(f => f.CPF == cpf);
        }

        // Obter todos os Funcionários
        public IEnumerable<Funcionario> ObterTodos()
        {
            return _context.Funcionario.ToList(); // Retorna uma lista vazia se não houver resultados
        }

        // Obter Funcionário por ID
        public Funcionario? ObterPorId(int id)
        {
            return _context.Funcionario.Find(id);
        }

        // Editar dados de um Funcionário existente
        public Funcionario? EditarDados(Funcionario funcionario)
        {
            var funcionarioExistente = _context.Funcionario.FirstOrDefault(f => f.FuncionarioID == funcionario.FuncionarioID);
            if (funcionarioExistente == null)
            {
                return null;
            }

            // Atualize os campos
            funcionarioExistente.Nome = funcionario.Nome;
            funcionarioExistente.CPF = funcionario.CPF;
            funcionarioExistente.Cargo = funcionario.Cargo;
            funcionarioExistente.Salario = funcionario.Salario;
            funcionarioExistente.DataContratacao = funcionario.DataContratacao;

            _context.Funcionario.Update(funcionarioExistente);
            _context.SaveChanges();  // Persistir as alterações
            return funcionarioExistente;
        }

        // Deletar um Funcionário por ID
        public Funcionario? DeletarDados(int id)
        {
            var funcionario = _context.Funcionario.FirstOrDefault(f => f.FuncionarioID == id);
            if (funcionario != null)
            {
                try
                {
                    _context.Funcionario.Remove(funcionario);
                    _context.SaveChanges();
                    return funcionario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao excluir o funcionário.", ex);
                }
            }
            throw new Exception("Funcionário não encontrado para a exclusão.");
        }
    }
}
