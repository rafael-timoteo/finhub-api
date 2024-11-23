using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    /// <inheritdoc />
    public class CentralGastosService(IInfoGastosService infoGastos) : ICentralGastosService
    {
        private readonly IInfoGastosService infoGastos = infoGastos;

        /// <inheritdoc />
        public Gasto MontarGasto(Transacao transacao)
        {
            var empresa = infoGastos.ConsultarCNPJ(transacao.Estabelecimento.Cnpj).Result;

            return new()
            {
                ClienteCPF = transacao.Cliente.Cpf,
                ClienteConta = transacao.Cliente.NumeroContaBancaria,
                NomeEmpresa = transacao.Estabelecimento.NomeEmpresa,
                DataGasto = transacao.Pagamento.Data,
                ValorGasto = transacao.Pagamento.Valor,
                Classificacao = ClassificacaoTransacao(empresa)
            };
        }

        /// <inheritdoc />
        public ClassificacaoCNAE ClassificacaoTransacao(EmpresaDTO empresa)
        {
            return infoGastos.ClassificarCNAE(empresa.CnaeFiscalPrincipal.Codigo.ToString());
        }
    }
}