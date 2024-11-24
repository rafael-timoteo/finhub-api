using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Interfaces
{
    /// <summary>
    /// Serviço de central de gastos do FinHub
    /// </summary>
    public interface ICentralGastosService
    {
        /// <summary>
        /// Serviço para criar um gasto.
        /// </summary>
        /// <param name="transacao"></param>
        public void CriarGasto(Transacao transacao);

        /// <summary>
        /// Serviço para obter o gasto por classificação e período de tempo.
        /// </summary>
        /// <param name="clienteCPF"></param>
        /// <param name="classificacao"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns>Valor do gasto</returns>
        public decimal GetGastoClassificacao(string clienteCPF, ClassificacaoTransacao classificacao, DateTime? dataInicio, DateTime? dataFim);

        /// <summary>
        /// Serviço para obter o gasto por conta e período de tempo.
        /// </summary>
        /// <param name="clienteCPF"></param>
        /// <param name="conta"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns>Valor do gasto</returns>
        public decimal GetGastoConta(string clienteCPF, string conta, DateTime? dataInicio, DateTime? dataFim);

        /// <summary>
        /// Serviço para montar o objeto de gasto.
        /// </summary>
        /// <param name="transacao">Dados da transação</param>
        /// <returns>Gasto</returns>
        public Gasto MontarGasto(Transacao transacao);

        /// <summary>
        /// Serviço para classificar a transação bancária.
        /// </summary>
        /// <param name="empresa">Dados da empresa</param>
        /// <returns>Classificação da transação</returns>
        public ClassificacaoTransacao ClassificarTransacao(EmpresaDTO empresa);
    }
}