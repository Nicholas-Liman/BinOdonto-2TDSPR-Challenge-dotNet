using Xunit;
using Moq;
using System;
using BinOdonto.Application.Dtos;
using BinOdonto.Domain.Entities;
using BinOdonto.Domain.Interfaces;
using BinOdonto.Service;

namespace BinOdonto.Tests.Application
{
    public class ClienteApplicationServiceTests
    {
        [Fact]
        public void SalvarDadosCliente_DeveChamarRepositorioComDadosCorretos()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            var service = new ClienteApplicationService(mockRepo.Object);

            var dto = new ClienteDTO
            {
                Nome = "João Silva",
                CPF = "12345678900",
                DataNascimento = new DateTime(1990, 1, 1),
                Email = "joao@email.com",
                CEP = "01001000"
            };

            Cliente? clienteSalvo = null;

            mockRepo.Setup(r => r.SalvarDados(It.IsAny<Cliente>()))
                    .Callback<Cliente>(c => clienteSalvo = c)
                    .Returns((Cliente c) => c);

            // Act
            var result = service.SalvarDadosCliente(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("João Silva", clienteSalvo?.Nome);
            Assert.Equal("12345678900", clienteSalvo?.CPF);
            Assert.Equal("01001000", clienteSalvo?.CEP);
        }
    }
}
