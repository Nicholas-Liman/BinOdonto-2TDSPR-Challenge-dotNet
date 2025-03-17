using System.Collections.Generic;
using BinOdonto.Application.Interfaces;

namespace BinOdonto.Service
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private readonly Dictionary<string, string> _configuracoes;

        public ConfiguracaoService()
        {
            // Simula configurações armazenadas
            _configuracoes = new Dictionary<string, string>
            {
                { "AppNome", "Sistema de Gestão Odontológica B.I.N." },
                { "Versao", "1.0.0" },
                { "Ambiente", "Desenvolvimento" }
            };
        }

        public string GetConfiguracao(string chave)
        {
            return _configuracoes.TryGetValue(chave, out var valor) ? valor : "Chave não encontrada";
        }
    }
}
