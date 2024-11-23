using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;
using FinHub.Infra;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    /// <inheritdoc />
    public class CentralGastosService(IInfoGastosService infoGastos, GastoRepository gastoRepository) : ICentralGastosService
    {
        private readonly IInfoGastosService infoGastos = infoGastos;
        private readonly GastoRepository gastoRepository = gastoRepository;

        /// <inheritdoc />
        public void CriarGasto(Transacao transacao)
        {
            var gasto = MontarGasto(transacao);
            InsertGastoBD(gasto);
        }

        /// <inheritdoc />
        public Gasto MontarGasto(Transacao transacao)
        {
            var empresa = infoGastos.ConsultarCNPJ(transacao.Estabelecimento.Cnpj).Result;

            return new()
            {
                ClienteCPF = transacao.Cliente.Cpf,
                ClienteConta = transacao.Cliente.NumeroContaBancaria,
                NomeEmpresa = empresa.NomeFantasia,
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

        /// <inheritdoc />
        private void InsertGastoBD(Gasto gasto)
        {
            gastoRepository.InsertGasto(gasto.ClienteCPF, 
                                gasto.ClienteConta, 
                                gasto.NomeEmpresa, 
                                gasto.DataGasto, 
                                gasto.ValorGasto, 
                                gasto.Classificacao.ToString());
        }
    }
}