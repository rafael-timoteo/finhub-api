using FinHub.Domain.Models;

namespace FinHub.Gastos.Domain.Transacoes.Interfaces
{
    /// <summary>
    /// Serviço de central de gastos do FinHub
    /// </summary>
    public interface ICentralGastosService
    {
        public string ProcessarGasto(Transacao transacao);
    }
}