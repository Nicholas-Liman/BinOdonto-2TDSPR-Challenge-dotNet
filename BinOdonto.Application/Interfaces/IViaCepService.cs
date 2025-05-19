using BinOdonto.Application.Dtos;
using System.Threading.Tasks;

namespace BinOdonto.Application.Interfaces
{
    public interface IViaCepService
    {
        Task<EnderecoResponseDto> ConsultarEnderecoAsync(string cep);
    }
}
