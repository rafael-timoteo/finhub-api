using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Interfaces
{
    public interface ICentralGastosService
    {
        public string ProcessarGasto(Transacao transacao);
    }
}