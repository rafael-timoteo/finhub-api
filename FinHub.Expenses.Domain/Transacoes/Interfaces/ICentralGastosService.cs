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
        public ClassificacaoCNAE ClassificacaoTransacao(EmpresaDTO empresa);
    }
}