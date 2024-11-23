namespace FinHub.Domain.Models
{
    /// <summary>
    /// Definição do objeto da transação financeira
    /// </summary>
    public class Transacao
    {
        /// <summary>
        /// Cliente que realizou a transação.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Dados de pagamento da transação.
        /// </summary>
        public Pagamento Pagamento { get; set; }

        /// <summary>
        /// Dados do estabelecimento da transação.
        /// </summary>
        public Estabelecimento Estabelecimento { get; set; }
    }
}