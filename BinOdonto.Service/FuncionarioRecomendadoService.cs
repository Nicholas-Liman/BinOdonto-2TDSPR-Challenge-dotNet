using BinOdonto.Application.ML;
using BinOdonto.Application.Interfaces;
using BinOdonto.Domain.Interfaces;
using Microsoft.ML;

namespace BinOdonto.Service
{
    public class FuncionarioRecomendadoService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IViaCepService _viaCepService;
        private readonly PredictionEngine<MLModel.ModelInput, MLModel.ModelOutput> _predictionEngine;

        public FuncionarioRecomendadoService(IFuncionarioRepository repo, IViaCepService viaCep)
        {
            _funcionarioRepository = repo;
            _viaCepService = viaCep;

            // Carrega o modelo treinado a partir do caminho absoluto
            var modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData", "MLModel.zip");
            var mlContext = new MLContext();
            var model = mlContext.Model.Load(modelPath, out _);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<MLModel.ModelInput, MLModel.ModelOutput>(model);
        }

        public async Task<Funcionario> ObterMaisProximo(string cepCliente)
        {
            // Converte CEP cliente para número
            int cepClienteNum = int.Parse(cepCliente.Replace("-", "").Trim());

            // Busca o endereço do cliente
            var enderecoCliente = await _viaCepService.ConsultarEnderecoAsync(cepCliente);

            // Obtém todos os funcionários
            var funcionarios = await _funcionarioRepository.GetAllAsync();

            Funcionario? melhorFuncionario = null;
            float maiorProbabilidade = 0f;

            foreach (var f in funcionarios)
            {
                if (string.IsNullOrEmpty(f.CEP))
                    continue;

                int cepFuncNum = int.Parse(f.CEP.Replace("-", "").Trim());
                int diff = Math.Abs(cepClienteNum - cepFuncNum);
                bool mesmoPrefixo = cepCliente.Substring(0, 3) == f.CEP.Substring(0, 3);

                var input = new MLModel.ModelInput
                {
                    Cep_cliente_num = cepClienteNum,
                    Cep_funcionario_num = cepFuncNum,
                    Diferenca_ceps = diff,
                    Mesmo_prefixo = mesmoPrefixo
                };

                var resultado = _predictionEngine.Predict(input);

                if (resultado.PredictedLabel && resultado.Probability > maiorProbabilidade)
                {
                    melhorFuncionario = f;
                    maiorProbabilidade = resultado.Probability;
                }
            }

            return melhorFuncionario!;
        }
    }
}
