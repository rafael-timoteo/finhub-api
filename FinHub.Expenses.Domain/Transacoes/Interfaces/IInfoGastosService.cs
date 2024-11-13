using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Interfaces
{
    public interface IInfoGastosService
    {
        public Task<Cnpj> ConsultarCNPJ(string cnpj);

        public TipoCNAE ClassificarCNAE(Cnpj cnpj);
    }
}