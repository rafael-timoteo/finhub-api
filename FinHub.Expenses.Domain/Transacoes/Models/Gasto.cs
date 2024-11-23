namespace FinHub.Gastos.Domain.Transacoes.Models
{
    /// <summary>
    /// Definição do objeto do gasto da transação financeira.
    /// </summary>
    public class Gasto
    {
        /// <summary>
        /// CPF do cliente
        /// </summary>
        public string ClienteCPF { get; set; }

        /// <summary>
        /// Conta bancária do cliente
        /// </summary>
        public string ClienteConta { get; set; }

        /// <summary>
        /// Descrição do gasto
        /// </summary>
        public string NomeEmpresa { get; set; }

        /// <summary>
        /// Data do gasto
        /// </summary>
        public DateTime DataGasto { get; set; }

        /// <summary>
        /// Valor do gasto
        /// </summary>
        public decimal ValorGasto { get; set; }

        /// <summary>
        /// Classificacao do gasto
        /// </summary>
        public ClassificacaoCNAE Classificacao { get; set; }
    }
}