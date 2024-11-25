using FinHub.Infra.Models;

namespace FinHub.Usuario.Domain.Interfaces
{
    /// <summary>
    /// Interface para serviços relacionados a extratos.
    /// </summary>
    public interface IExtratoService
    {
        /// <summary>
        /// Retorna informações da conta corrente.
        /// </summary>
        /// <returns>Lista com informações de id_banco, saldo e tipo_conta.</returns>
        List<ContaCorrenteDTO> ObterInformacoesContaCorrente(string cpf);

        public decimal ObterSaldo(string cpf);

        public List<EntradaSaidaDTO> ObterEntradas(string cpf);

        public List<EntradaSaidaDTO> ObterSaidas(string cpf);
    }
}