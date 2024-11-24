using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.API.DTOs.Requests
{
    public class GastosPorClassificacaoRequest
    {
        public string ClienteCPF { get; set; }

        public ClassificacaoTransacao Classificacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
    }
}