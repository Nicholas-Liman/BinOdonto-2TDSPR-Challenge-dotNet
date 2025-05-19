using Xunit;
using System;
using BinOdonto.Application.Dtos;
using BinOdonto.Service;
using BinOdonto.Data.AppData;
using BinOdonto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BinOdonto.Tests.Application
{
    public class FuncionarioApplicationServiceTests
    {
        [Fact]
        public void SalvarDadosFuncionario_DevePersistirComSucesso()
        {
            // Arrange - banco de dados em memória
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "FuncionarioTestDb")
                .Options;

            using var context = new ApplicationDbContext(options);
            var service = new FuncionarioApplicationService(context);

            var dto = new FuncionarioDTO
            {
                Nome = "Maria",
                CPF = "98765432100",
                Cargo = "Dentista",
                Salario = 5000,
                DataContratacao = DateTime.Today,
                CEP = "01002000"
            };

            // Act
            var result = service.SalvarDadosFuncionario(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Maria", result.Nome);
            Assert.Equal("01002000", result.CEP);
        }
    }
}
