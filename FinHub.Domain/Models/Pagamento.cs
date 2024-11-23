namespace FinHub.Domain.Models
{
    /// <summary>
    /// Definição do objeto pagamento.
    /// </summary>
    public class Pagamento
    {
        /// <summary>
        /// Tipo de pagamento realizado.
        /// </summary>
        public TipoPagamento TipoPagamento { get; set; }

        /// <summary>
        /// Data do pagamento.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Valor do pagamento.
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Número da conta bancária que foi feita o pagamento.
        /// </summary>
        public string NumeroContaBancaria { get; set; }
    }

    /// <summary>
    /// Definição dos tipos de pagamentos realizados nas transações financeiras.
    /// </summary>
    public enum TipoPagamento
    {
        /// <summary>
        /// Pagamento via pix.
        /// </summary>
        Pix,

        /// <summary>
        /// Pagamento via cartão de crédito.
        /// </summary>
        Credito,

        /// <summary>
        /// Pagamento via cartão de débito.
        /// </summary>
        Debito
    }
}