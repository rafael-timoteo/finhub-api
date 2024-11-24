using FinHub.Infra;
using FinHub.Infra.Models;
using FinHub.Usuario.Domain.Interfaces;

namespace FinHub.Usuario.Domain.Services
{
    public class ExtratoService : IExtratoService
    {
        public List<ContaCorrenteDTO> ObterInformacoesContaCorrente(string numeroConta)
        {
            return ContaCorrenteRepository.ObterDadosContaCorrente(numeroConta);
        }
    }
}