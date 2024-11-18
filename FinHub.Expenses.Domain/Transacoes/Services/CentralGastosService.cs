using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    public class CentralGastosService(IInfoGastosService infoGastos) : ICentralGastosService
    {
        private readonly IInfoGastosService infoGastos = infoGastos;

        public string ProcessarGasto(Transacao transacao)
        {
            var empresa = infoGastos.ConsultarCNPJ(transacao.Estabelecimento.Cnpj);

            TipoCNAE classificacaoTransacao = infoGastos.ClassificarCNAE(empresa.Result.CnaeFiscalPrincipal.Codigo.ToString()!);

            return classificacaoTransacao.ToString();
        }
    }
}