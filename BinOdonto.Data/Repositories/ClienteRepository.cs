using BinOdonto.Domain.Entities;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Data.AppData;

namespace BinOdonto.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cliente? DeletarDados(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.ClienteID == id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                _context.SaveChanges();
                return cliente;
            }
            throw new Exception("Cliente não encontrado para a exclusão.");
        }

        public Cliente? EditarDados(Cliente entity)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.ClienteID == entity.ClienteID);
            if (cliente != null)
            {
                cliente.Nome = entity.Nome;
                cliente.CPF = entity.CPF;
                cliente.DataNascimento = entity.DataNascimento;
                cliente.Email = entity.Email;

                _context.Cliente.Update(cliente);
                _context.SaveChanges();
                return cliente;
            }
            throw new Exception("Cliente não encontrado para a edição.");
        }

        public Cliente? ObterPorId(int id)
        {
            return _context.Cliente.Find(id);
        }

        public IEnumerable<Cliente>? ObterTodos()
        {
            var clientes = _context.Cliente.ToList();
            return clientes.Any() ? clientes : null;
        }

        public Cliente? SalvarDados(Cliente entity)
        {
            _context.Cliente.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
