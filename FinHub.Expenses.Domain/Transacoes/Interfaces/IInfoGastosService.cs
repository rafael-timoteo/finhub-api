using FinHub.Gastos.Domain.Transacoes.Models;

namespace FinHub.Gastos.Domain.Transacoes.Interfaces
{
    /// <summary>
    /// Serviço para consultar informações a partir do gasto.
    /// </summary>
    public interface IInfoGastosService
    {
        /// <summary>
        /// Consulta o CNPJ da empresa.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>Objeto com dados da empresa</returns>
        public Task<EmpresaDTO> ConsultarCNPJ(string cnpj);

        /// <summary>
        /// Classifica o CNAE da empresa.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>Classificacao do CNAE</returns>
        public ClassificacaoCNAE ClassificarCNAE(string cnpj);
    }
}