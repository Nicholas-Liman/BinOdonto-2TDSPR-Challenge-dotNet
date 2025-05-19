using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using BinOdonto.Application.Dtos;
using BinOdonto.Service;
using RichardSzalay.MockHttp;

namespace BinOdonto.Tests.Services
{
    public class ViaCepServiceTests
    {
        [Fact]
        public async Task DeveRetornarEnderecoCorretoDoViaCep()
        {
            // Arrange
            var cep = "01001000";
            var responseJson = JsonSerializer.Serialize(new EnderecoResponseDto
            {
                Cep = "01001-000",
                Logradouro = "Praça da Sé",
                Bairro = "Sé",
                Localidade = "São Paulo",
                Uf = "SP",
                Ddd = "11"
            });

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When($"https://viacep.com.br/ws/{cep}/json/")
                    .Respond("application/json", responseJson);

            var httpClient = new HttpClient(mockHttp);
            var service = new ViaCepService(httpClient);

            // Act
            var endereco = await service.ConsultarEnderecoAsync(cep);

            // Assert
            Assert.NotNull(endereco);
            Assert.Equal("São Paulo", endereco.Localidade);
            Assert.Equal("SP", endereco.Uf);
            Assert.Equal("Praça da Sé", endereco.Logradouro);
        }
    }
}
