using FinHub.Infra;
using FinHub.Infra.Models;
using FinHub.Usuario.Domain.Interfaces;

namespace FinHub.Usuario.Domain.Services
{
    public class ExtratoService : IExtratoService
    {
        public List<ContaCorrenteDTO> ObterInformacoesContaCorrente(string numeroConta)
        {
            return ExtratoRepository.ObterDadosContaCorrente(numeroConta);
        }

        public decimal ObterSaldo(string cpf)
        {
            return ExtratoRepository.ObterSaldoTotal(cpf);
        }

        public List<EntradaSaidaDTO> ObterEntradas(string cpf)
        {
            return ExtratoRepository.ObterEntradasConta(cpf);
        }

        public List<EntradaSaidaDTO> ObterSaidas(string cpf)
        {
            return ExtratoRepository.ObterSaidasConta(cpf);
        }
    }
}