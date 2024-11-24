using FinHub.Domain.Models;
using FinHub.Gastos.Domain.Transacoes.Interfaces;
using FinHub.Gastos.Domain.Transacoes.Models;
using FinHub.Infra;

namespace FinHub.Gastos.Domain.Transacoes.Services
{
    /// <inheritdoc />
    public class CentralGastosService(IInfoGastosService infoGastos) : ICentralGastosService
    {
        private readonly IInfoGastosService infoGastos = infoGastos;

        /// <inheritdoc />
        public void CriarGasto(Transacao transacao)
        {
            var gasto = MontarGasto(transacao);
            InsertTransacaoBD(gasto);
        }

        /// <inheritdoc />
        public decimal GetGastoClassificacao(string clienteCPF, ClassificacaoTransacao classificacao, DateTime dataInicio, DateTime dataFim)
        {
            if (GastoRepository.ConferirCPF(clienteCPF))
            {
                return GastoRepository.SelectGastoClassificacao(clienteCPF, classificacao.ToString(), dataInicio, dataFim);
            }
            else
            {
                throw new Exception("CPF não encontrado");
            }
        }

        /// <inheritdoc />
        public Gasto MontarGasto(Transacao transacao)
        {
            var empresa = infoGastos.ConsultarCNPJ(transacao.Estabelecimento.Cnpj).Result;

            ClassificacaoTransacao classificacao;
            decimal valorGasto;

            if (transacao.Estabelecimento.NumeroContaBancaria == transacao.Cliente.NumeroContaBancaria)
            {
                classificacao = ClassificacaoTransacao.Entrada;
                valorGasto = transacao.Pagamento.Valor;
            }
            else
            {
                classificacao = ClassificarTransacao(empresa);
                valorGasto = -transacao.Pagamento.Valor;
            }

            return new()
            {
                ClienteCPF = transacao.Cliente.Cpf,
                ClienteConta = transacao.Cliente.NumeroContaBancaria,
                NomeEmpresa = empresa.NomeFantasia,
                DataGasto = transacao.Pagamento.Data,
                ValorGasto = valorGasto,
                Classificacao = classificacao
            };
        }

        /// <inheritdoc />
        public ClassificacaoTransacao ClassificarTransacao(EmpresaDTO empresa)
        {
            return infoGastos.ClassificarCNAE(empresa.CnaeFiscalPrincipal.Codigo.ToString());
        }

        /// <inheritdoc />
        private void InsertTransacaoBD(Gasto gasto)
        {
            GastoRepository.InsertTransacao(gasto.ClienteCPF,
                                gasto.ClienteConta,
                                gasto.NomeEmpresa,
                                gasto.DataGasto,
                                gasto.ValorGasto,
                                gasto.Classificacao.ToString());
        }
    }
}