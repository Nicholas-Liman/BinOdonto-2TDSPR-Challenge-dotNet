﻿using Microsoft.EntityFrameworkCore;
using BinOdonto.Domain.Entities;
using BinOdonto.Application.Dtos;
using BinOdonto.Data.AppData;

namespace BinOdonto.Service
{
    public class ClienteService
    {
        private readonly ApplicationDbContext _context; 

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException("Cliente não encontrado.");
            }
            return cliente;
        }

        public async Task<Cliente> AddClienteAsync(ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = new Cliente
                {
                    ClienteID = clienteDTO.ClienteID,
                    Nome = clienteDTO.Nome,
                    CPF = clienteDTO.CPF,
                    DataNascimento = clienteDTO.DataNascimento,
                    Email = clienteDTO.Email
                };
                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar cliente.", ex);
            }
        }

        public async Task<Cliente?> UpdateClienteAsync(int id, ClienteDTO clienteDTO)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return null;

            cliente.Nome = clienteDTO.Nome;
            cliente.CPF = clienteDTO.CPF;
            cliente.DataNascimento = clienteDTO.DataNascimento;
            cliente.Email = clienteDTO.Email;

            try
            {
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar cliente.", ex);
            }
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return false;

            try
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar cliente.", ex);
            }
        }
    }
}
