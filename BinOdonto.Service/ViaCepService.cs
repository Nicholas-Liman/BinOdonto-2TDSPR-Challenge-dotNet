using BinOdonto.Application.Dtos;
using BinOdonto.Application.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BinOdonto.Service
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoResponseDto> ConsultarEnderecoAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EnderecoResponseDto>(json);
        }
    }
}
